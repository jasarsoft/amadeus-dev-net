using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class OfferItem
    {
        public ICollection<Service> Services { get; set; } 

        public Price Price { get; set; }
        public Price PricePerAdult { get; set; }
        public Price PricePerInfant { get; set; }
        public Price PricePerChild { get; set; }
        public Price PricePerSenior { get; set; }
    }
}
