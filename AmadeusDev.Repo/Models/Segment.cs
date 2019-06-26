using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class Segment
    {
        public FlightSegment FlightSegment { get; set; }

        public PricingDetail PricingDetailPerAdult { get; set; }
        public PricingDetail PricingDetailPerInfant { get; set; }
        public PricingDetail PricingDetailPerChild { get; set; }
        public PricingDetail PricingDetailPerSenior { get; set; }
    }
}
