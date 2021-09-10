using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OceanicAirlines.DataAccessLayer;
using OceanicAirlines.Models;

namespace OceanicAirlines.ViewModels
{
    public class SearchRouteViewModel
    {
        public string OriginCity { get; set; }
        public string DestinationCity { get; set; }
        public double Discount { get; set; }
        public double Weight { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public IEnumerable<OceanicAirlines.Models.City> cities { get; set; }
        public Dimensions Dimensions { get; set; }
        public ParcelType ParcelTypeEnumValue { get; set; }

        public SearchRouteViewModel()
        {
            
        }
    }
}