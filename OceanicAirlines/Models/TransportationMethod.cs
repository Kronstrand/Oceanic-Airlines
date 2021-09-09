using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public enum Company { TelstarLogistics, EastIndiaTrading, OceanicAirlines}
    public enum TransportationType { TelstarLogistics, EastIndiaTrading, OceanicAirlines}
    public class TransportationMethod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TransportationMethodID { get; set; }
        public Company Company { get; set; }
        public TransportationType TransportationType { get; set; }

        public virtual ICollection<Route> Routes { get; set; }
    }
}