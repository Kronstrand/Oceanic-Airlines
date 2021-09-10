using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using OceanicAirlines.DTO;

namespace OceanicAirlines.Api
{
    public class AccesExternalApi
    {
        public RouteDetailsDTO GetExternalResponse(string address, RouteSearchDTO search)
        {
            var client = new HttpClient();
            var postTask = client.PostAsJsonAsync<RouteSearchDTO>(address, search);

            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<RouteDetailsDTO>();
                readTask.Wait();

                var routeDetails = readTask.Result;
                return routeDetails;
            }
            else
            {
                return null;
            }

        }
        public string ConvertLocationToExport(string locationInput)
        {
            char[] charsToTrim = { '.', ' '};
            return locationInput.Trim(charsToTrim);
        }
        public string ConvertLocationFromExport(string locationInput)
        {
            String locationOutput = locationInput.Replace("St", "St. ");
            bool noChanges = false;
            while (noChanges == false)
            {
                noChanges = true;
                for (int i = 1; i < locationOutput.Length; i++)
                {
                    if (char.IsUpper(locationOutput, i)) 
                    {
                        locationOutput.Insert(i-1, " ");
                        noChanges = false;
                        break;
                    }
                }
            }
            return locationOutput;
        }
    }

    
}