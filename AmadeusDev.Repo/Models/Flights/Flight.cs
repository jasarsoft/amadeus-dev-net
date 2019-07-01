using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class Flight
    {
        public ICollection<FlightOffer> Data { get; set; }
        public Dictionaries Dictionaries { get; set; }
        public Meta Meta { get; set; }
        public ICollection<Issue> Warnings { get; set; }


        public static implicit operator Data.Flights.Flight(Models.Flights.Flight model)
        {
            return new Data.Flights.Flight
            {
                
            };
        }
    }
}
