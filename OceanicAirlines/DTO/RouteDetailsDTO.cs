using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OceanicAirlines.DTO
{
    public class RouteDetailsDTO
    {
        public Decimal Price { get; set; }
        public int TravelTime { get; set; }

        public String ErrorMessage { get; set; } 
    }
}