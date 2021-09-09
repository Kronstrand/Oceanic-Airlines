using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Oceanic_Airlines.DTO;
using OceanicAirlines.Api;

namespace Oceanic_Airlines.Api
{
    [Route("api/test/tl/GetRouteDetails")]
    public class TelstarLogisticsApiController : ApiController
    {

        static string _address = "http://wa-tl-dk1.azurewebsites.net//delivery/getRouteDetails";

        public IHttpActionResult Post(RouteSearchDTO search)
        {
            //search = new RouteSearchDTO {Origin = "Hvalbugten", Destination = "Kapstaden", ParcelType = 6, Depth = 1.1f, Height = 1.1f, Width = 1.1f, Weight = 2, Month = 6};
            var result = GetExternalResponse(search);
            return Json(result);
        }

        public RouteDetailsDTO GetExternalResponse(RouteSearchDTO search)
        {
            var apiAcces = new AccesExternalApi();
            return apiAcces.GetExternalResponse(_address, search);
        }
    }
}