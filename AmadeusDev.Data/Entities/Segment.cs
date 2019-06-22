using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Segment
    {
        //flightSegment(FlightSegment, optional),
        //pricingDetailPerAdult(PricingDetail, optional),
        //pricingDetailPerInfant(PricingDetail, optional),
        //pricingDetailPerChild(PricingDetail, optional),
        //pricingDetailPerSenior(PricingDetail, optional)
        public FlightSegment flightSegment { get; set; }
        public PricingDetail pricingDetailPerAdult { get; set; }
        public PricingDetail pricingDetailPerInfant { get; set; }
        public PricingDetail pricingDetailPerChild { get; set; }
        public PricingDetail pricingDetailPerSenior { get; set; }
    }
}
