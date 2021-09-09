using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public class Route
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RouteID { get; set; }

        [Required]
        [Display(Name = "Origin City")]
        [ForeignKey("Origin"), Column(Order = 0)]
        public Guid OriginID { get; set; }
        public virtual City Origin { get; set; }

        [Required]
        [Display(Name = "Destination City")]
        [ForeignKey("Destination"), Column(Order = 1)]
        public Guid DestinationID { get; set; }
        public virtual City Destination { get; set; }

        public Guid TransportationMethodID { get; set; }
        public virtual TransportationMethod TransportationMethod { get; set; }
        public TimeSpan? Timespan { get; set; }
        public bool Available { get; set; }
    }
}