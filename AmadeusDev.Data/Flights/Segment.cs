using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Segments", Schema = "Flight")]
    public class Segment
    {
        [Key]
        public int SegmentId { get; set; }

        [ForeignKey(nameof(FlightSegment))]
        public int FlightSegmentId { get; set; }
        public FlightSegment FlightSegment { get; set; }

        [ForeignKey(nameof(PricingDetailPerAdult))]
        public int? PricingDetailPerAdultId { get; set; }
        public virtual PricingDetail PricingDetailPerAdult { get; set; }

        [ForeignKey(nameof(PricingDetailPerInfant))]
        public int? PricingDetailPerInfantId { get; set; }
        public virtual PricingDetail PricingDetailPerInfant { get; set; }
        
        [ForeignKey(nameof(PricingDetailPerChild))]
        public int? PricingDetailPerChildId { get; set; }
        public virtual PricingDetail PricingDetailPerChild { get; set; }

        [ForeignKey(nameof(PricingDetailPerSenior))]
        public int? PricingDetailPerSeniorId { get; set; }
        public virtual PricingDetail PricingDetailPerSenior { get; set; }


        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
