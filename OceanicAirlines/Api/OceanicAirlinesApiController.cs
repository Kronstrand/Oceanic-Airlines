using System;
using System.Collections.Generic;
using System.Web.Http;
using Oceanic_Airlines.Business_Logic;
using Oceanic_Airlines.DTO;

namespace Oceanic_Airlines.Api
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