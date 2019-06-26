using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class FlightStop
    {
        public string IataCode { get; set; } 

        public AircraftEquipment NewAircraft { get; set; }

        public string Duration { get; set; }
        public string ArrivalAt { get; set; } 
        public string DepartureAt { get; set; }
    }
}
