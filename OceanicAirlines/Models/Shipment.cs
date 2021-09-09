using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public class Shipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ShipmentID { get; set; }

        public Guid ParcelID { get; set; }
        public virtual Parcel Parcel { get; set; }

        public double Price { get; set; }
        public TimeSpan Timespan { get; set; }

        public IList<Route> Routes { get; set; }
    }
}