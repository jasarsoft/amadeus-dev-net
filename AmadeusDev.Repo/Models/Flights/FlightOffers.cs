using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class FlightOffers
    {
        public ICollection<FlightOffer> Data { get; set; }
        public Dictionaries Dictionaries { get; set; }
        public Meta Meta { get; set; }
        public ICollection<Issue> Warnings { get; set; }
    }
}
