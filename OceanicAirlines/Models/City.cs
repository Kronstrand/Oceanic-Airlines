using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid CityID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Route> OriginCityRoutes { get; set; }
        public virtual ICollection<Route> DestinationCityRoutes { get; set; }
        public virtual ICollection<Parcel> OriginCityParcel { get; set; }
        public virtual ICollection<Parcel> DestinationCityParcel { get; set; }
    }
}