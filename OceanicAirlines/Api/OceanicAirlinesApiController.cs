using System;
using System.Collections.Generic;
using System.Web.Http;
using OceanicAirlines.Business_Logic;
using OceanicAirlines.DTO;

namespace OceanicAirlines.Api
{
    [Route("api/GetRouteDetails")]
    public class OceanicAirlinesApiController : ApiController
    {
        public IHttpActionResult Post(RouteSearchDTO search)
        {
            HandleRoutes routes = new HandleRoutes();
            String resultPath = routes.PrepareKShortestPaths();

            List<ResultPathDTO> resultPathDTOs = routes.GetResultPathDTOs();

            return Json(new RouteDetailsDTO { Price = Convert.ToInt32(resultPathDTOs[0].totalCostInDollars), TravelTime = Convert.ToInt32(resultPathDTOs[0].totalCostInHours.TotalHours), ErrorMessage = ""});
        }
    }
}