using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class FlightSegment
    {
        public FlightEndPoint Departure { get; set; }
        public FlightEndPoint Arrival { get; set; }

        public string CarrierCode { get; set; }
        public string Number { get; set; }

        public AircraftEquipment Aircraft { get; set; }
        public OperatingFlight Operating { get; set; }

        public string Duration { get; set; }

        public ICollection<FlightStop> Stops { get; set; }
    }
}
