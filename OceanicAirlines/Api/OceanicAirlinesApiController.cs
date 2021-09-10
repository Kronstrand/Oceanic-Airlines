using System.Web.Http;
using OceanicAirlines.DTO;

namespace OceanicAirlines.Api
{
    [Route("api/GetRouteDetails")]
    public class OceanicAirlinesApiController : ApiController
    {
        public IHttpActionResult Post(RouteSearchDTO search)
        {
            return Json(new RouteDetailsDTO { Price = 200, TravelTime = 8, ErrorMessage = ""});
        }
    }
}