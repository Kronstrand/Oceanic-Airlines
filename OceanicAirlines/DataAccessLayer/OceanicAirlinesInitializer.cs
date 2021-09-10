using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OceanicAirlines.Models;
using System.IO;
using System.Globalization;
using System.Text;

namespace OceanicAirlines.DataAccessLayer
{
    public class OceanicAirlinesInitializer : DropCreateDatabaseIfModelChanges<OceanicAirlinesContext>
    {
        protected override void Seed(OceanicAirlinesContext context)
        {
            // Setup cities
            AddCity(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Cities.txt");
            AddDimensions(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Dimensions.txt");
            AddParcels(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Parcels.txt");
            AddTransportationMethods(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\TransportationMethod.txt");
            AddRoutes(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Routes.txt");
            AddShipments(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Shipments.txt");
        }

        private void AddTransportationMethods(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {
                var splits = line.Split(',').ToList();
                if (splits.Count != 2)
                {
                    continue;
                }
                var method = new TransportationMethod
                {
                    TransportationMethodID = Guid.NewGuid(),
                    Company = (Company)Enum.ToObject(typeof(Company), Int32.Parse(splits[0])),
                    TransportationType = (TransportationType)Enum.ToObject(typeof(TransportationType), Int32.Parse(splits[1])),
                };
                context.TransportationMethods.Add(method);
                counter++;
            }
            file.Close();
            context.SaveChanges();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddShipments(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {

            }
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddParcels(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {
                var splits = line.Split(',').ToList();
                if (splits.Count != 7)
                {
                    continue;
                }
                var parcel = new Parcel
                {
                    ParcelID = Guid.NewGuid(),
                    ParcelType = (ParcelType)Enum.ToObject(typeof(ParcelType), Int32.Parse(splits[0])),
                    Weight = double.Parse(splits[1], CultureInfo.InvariantCulture),
                    OriginID = GetCityID(context, splits[2]),
                    DestinationID = GetCityID(context, splits[3]),
                    Discount = double.Parse(splits[4], CultureInfo.InvariantCulture),
                    ShippingDate = DateTime.ParseExact(splits[5], "dd/mm/yyyy", CultureInfo.InvariantCulture),
                    DimensionsID = GetDimentionsID(context, splits[6])
                };
                context.Parcels.Add(parcel);
                counter++;
            }
            file.Close();
            context.SaveChanges();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private Guid GetDimentionsID(OceanicAirlinesContext context, string categoryString)
        {
            var category = (Category)Enum.ToObject(typeof(Category), Int32.Parse(categoryString));
            var dimensionsID = context.Dimensions.Where(x => x.Category == category).Select(x => x.DimensionsID).FirstOrDefault();
            if (dimensionsID != null)
            {
                return dimensionsID;
            }
            return context.Dimensions.Select(x => x.DimensionsID).FirstOrDefault();
        }

        private Guid GetCityID(OceanicAirlinesContext context, string cityName)
        {
            var cityID = context.Cities.Where(x => x.Name == cityName).Select(x => x.CityID).FirstOrDefault();
            if (cityID != null && cityID != Guid.Empty)
            {
                return cityID;
            }
            var city = new City { CityID = Guid.NewGuid(), Name = cityName };
            context.Cities.Add(city);
            context.SaveChanges();
            return city.CityID;
        }

        private void AddDimensions(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {
                var splits = line.Split(',').ToList();
                if(splits.Count != 4)
                {
                    continue;
                }
                var dimension = new Dimensions { 
                    DimensionsID = Guid.NewGuid(), 
                    Category = (Category)Enum.ToObject(typeof(Category), Int32.Parse(splits[0])),
                    Depth = double.Parse(splits[1], CultureInfo.InvariantCulture),
                    Width = double.Parse(splits[2], CultureInfo.InvariantCulture),
                    Length = double.Parse(splits[3], CultureInfo.InvariantCulture),
                };
                context.Dimensions.Add(dimension);
                counter++;
            }
            file.Close();
            context.SaveChanges();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddCity(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {
                var city = new City { CityID = Guid.NewGuid(), Name = line };
                context.Cities.Add(city);
                counter++;
            }
            file.Close();
            context.SaveChanges();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddRoutes(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {
                var splits = line.Split(',').ToList();
                if (splits.Count != 5)
                {
                    continue;
                }
                var route = new Route
                {
                    RouteID = Guid.NewGuid(),
                    OriginID = GetCityID(context, splits[0]),
                    DestinationID = GetCityID(context, splits[1]),
                    TransportationMethodID = GetTransportID(context, splits[2]),
                    Timespan = string.IsNullOrEmpty(splits[3]) ? (TimeSpan?) null : TimeSpan.FromHours(Int32.Parse(splits[3])),
                    Available = splits[4] == "true" ? true : false
                };
                context.Routes.Add(route);
                counter++;
            }
            file.Close();
            context.SaveChanges();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private Guid GetTransportID(OceanicAirlinesContext context, string companyString)
        {
            var company = (Company)Enum.ToObject(typeof(Company), Int32.Parse(companyString));
            var methodID = context.TransportationMethods.Where(x => x.Company == company).Select(x => x.TransportationMethodID).FirstOrDefault();
            if (methodID != null)
            {
                return methodID;
            }
            return context.TransportationMethods.Select(x => x.TransportationMethodID).FirstOrDefault();
        }

        private StreamReader GetFile(string path)
        {
            if (File.Exists(path)){
                var fileStream = File.Open(path, FileMode.Open);
                return new StreamReader(fileStream, Encoding.UTF8);
            }
            else
            {
                var fileStream = File.Open(path, FileMode.Create);
                fileStream.Close();
                fileStream = File.Open(path, FileMode.Open);
                return new StreamReader(fileStream, Encoding.UTF8);
            }
        }
    }
}