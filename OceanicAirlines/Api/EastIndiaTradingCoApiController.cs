using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Oceanic_Airlines.DTO;
using OceanicAirlines.Api;

namespace Oceanic_Airlines.Api
{
    [Route("api/test/ei/GetRouteDetails")]
    public class EastIndiaTradingCoApiController : ApiController
    {

        static string _address = "http://wa-eit-dk1.azurewebsites.net/api/EITCAPI/getConnection";

        public IHttpActionResult Post(RouteSearchDTO search)
        {
            //search = new RouteSearchDTO {Depth = 1.1f };
            var result = GetExternalResponse(search);
            return Json(result);
        }

        public RouteDetailsDTO GetExternalResponse (RouteSearchDTO search)
        {
            var apiAcces = new AccesExternalApi();
            return apiAcces.GetExternalResponse(_address, search); 
        }
    }
}