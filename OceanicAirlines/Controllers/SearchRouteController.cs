using OceanicAirlines.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OceanicAirlines.Controllers
{
    public class SearchRouteController : Controller
    {
        public ActionResult SearchRoute()
        {
            HandleRoutes routes = new HandleRoutes();
            String resultPath = routes.PrepareKShortestPaths();

            List<ResultPathDTO> resultPathDTOs = routes.GetResultPathDTOs();
            ViewBag.Message = "";
            foreach (ResultPathDTO result in resultPathDTOs)
            {
                ViewBag.Message += result.getMessageString();
            }
            return View();
        }
    }
}