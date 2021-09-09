using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oceanic_Airlines.DTO
{
    public class RouteSearchDTO
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Weight { get; set; }
        public int Month { get; set; }
        public int ParcelType { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
    }
}