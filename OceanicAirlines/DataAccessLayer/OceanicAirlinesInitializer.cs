using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using OceanicAirlines.Models;
using System.IO;

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
            AddRoutes(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Routes.txt");
            AddShipments(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\Shipments.txt");
            AddTransportationMethods(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\TransportationMethod.txt");
            AddUsers(context, "C:\\Users\\emid\\OneDrive - Netcompany\\Desktop\\Oceanic-Airlines\\OceanicAirlines\\DataSetup\\User.txt");
        }

        private void AddUsers(OceanicAirlinesContext context, string path)
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

        private void AddTransportationMethods(OceanicAirlinesContext context, string path)
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

            }
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddDimensions(OceanicAirlinesContext context, string path)
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
            Console.WriteLine("There were {0} lines.", counter);
        }

        private void AddRoutes(OceanicAirlinesContext context, string path)
        {
            int counter = 0;
            string line;

            var file = GetFile(path);
            while ((line = file.ReadLine()) != null)
            {

            }
            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
        }

        private StreamReader GetFile(string path)
        {
            if (File.Exists(path)){
                var fileStream = File.Open(path, FileMode.Open);
                return new StreamReader(fileStream);
            }
            else
            {
                var fileStream = File.Open(path, FileMode.Create);
                fileStream.Close();
                fileStream = File.Open(path, FileMode.Open);
                return new StreamReader(fileStream);
            }
        }
    }
}