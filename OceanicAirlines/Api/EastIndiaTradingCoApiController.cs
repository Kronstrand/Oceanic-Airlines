using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Oceanic_Airlines.DTO;

namespace Oceanic_Airlines.Api
{
    [Route("api/test/ei/GetRouteDetails")]
    public class EastIndiaTradingCoApiController : ApiController
    {

        static string _address = "http://wa-ei-dk1.azurewebsites.net/api/GetRouteDetails";

        public async void Post(RouteSearchDTO search)
        {
            var result = await GetExternalResponse(search);
        }

        private async Task<string> GetExternalResponse(RouteSearchDTO search)
        {
            var client = new HttpClient();
            var payload = JsonConvert.SerializeObject(search);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(_address, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}