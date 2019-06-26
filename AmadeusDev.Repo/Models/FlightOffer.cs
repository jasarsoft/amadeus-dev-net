using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class FlightOffer
    {
        public string Type { get; set; }
        public string Id { get; set; } 
        public ICollection<OfferItem> OfferItems { get; set; }
    }
}
