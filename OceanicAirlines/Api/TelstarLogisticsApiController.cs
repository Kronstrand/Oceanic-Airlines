using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using OceanicAirlines.DTO;
using OceanicAirlines.Api;

namespace OceanicAirlines.Api
{
    [Route("api/test/tl/GetRouteDetails")]
    public class TelstarLogisticsApiController : ApiController
    {

        static string _address = "http://wa-tl-dk1.azurewebsites.net/api/GetRouteDetails";
        //static string _address = "https://localhost:44375//api/GetRouteDetails";
        
        public async void Post(RouteSearchDTO search)
        {
            var result = await GetExternalResponse(search);
        }

        private async Task<string> GetExternalResponse(RouteSearchDTO search)
        {
            var client = new HttpClient();
            string json = await Task.Run(() => JsonConvert.SerializeObject(search));
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(_address, null);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}