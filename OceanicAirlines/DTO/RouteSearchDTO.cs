using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OceanicAirlines.DTO
{
    public class RouteSearchDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public float Weight { get; set; }
        public int Month { get; set; }
        public int ParcelType { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Width { get; set; }
    }
}