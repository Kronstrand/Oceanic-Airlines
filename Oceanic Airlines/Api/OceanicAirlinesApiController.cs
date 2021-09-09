using System.Web.Http;
using Oceanic_Airlines.DTO;

namespace Oceanic_Airlines.Api
{
    [Route("api/GetRouteDetails")]
    public class OceanicAirlinesApiController : ApiController
    {
        public IHttpActionResult Post(RouteSearchDTO search)
        {
            return Json(new RouteDetailsDTO { Price = 200, TravelTime = 8 });
        }
    }
}