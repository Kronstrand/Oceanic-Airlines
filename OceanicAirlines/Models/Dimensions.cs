using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanicAirlines.Models
{
    public enum Category { A, B, C };
    public class Dimensions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid DimensionsID { get; set; }
        public Category Category { get; set; }
        public double Depth { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
}