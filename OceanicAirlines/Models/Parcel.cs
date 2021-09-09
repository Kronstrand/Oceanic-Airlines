using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OceanicAirlines.Models
{
    public enum ParcelType
    { 
        Weapon = 1, Recorded = 2, Animal = 3, Caution = 4, Refridge = 5, Other = 6
    }

    public class Parcel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ParcelID { get; set; }
        public ParcelType ParcelType { get; set; }

        public double Weight { get; set; }
        public double Discount { get; set; }
        public DateTime ShippingDate { get; set; }

        public Guid DimensionsID { get; set; }
        public virtual Dimensions Dimensions { get; set; }

        [ForeignKey("Origin"), Column(Order = 0)]
        public Guid OriginID { get; set; }
        public virtual City Origin { get; set; }

        [ForeignKey("Destination"), Column(Order = 1)]
        public Guid DestinationID { get; set; }
        public virtual City Destination { get; set; }

        public virtual ICollection<Shipment> Shimpents { get; set; }
    }
}