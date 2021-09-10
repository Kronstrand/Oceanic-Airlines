using OceanicAirlines.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OceanicAirlines.ViewModels;

namespace OceanicAirlines.Controllers
{
    public class SearchRouteController : Controller
    {
        OceanicAirlines.ViewModels.SearchRouteViewModel model;
        public ActionResult SearchRoute()
        {
            

            model = new SearchRouteViewModel();
            return View(model);
        }

        public ActionResult SubmitData(string originCity, string destinationCity)
        {
            HandleRoutes routes = new HandleRoutes();
            String resultPath = routes.PrepareKShortestPaths(originCity, destinationCity);

            List<ResultPathDTO> resultPathDTOs = routes.GetResultPathDTOs();
            ViewBag.Message = "";
            foreach (ResultPathDTO result in resultPathDTOs)
            {
                ViewBag.Message += result.getMessageString();
            }

            return View(model);
        }
    }
}