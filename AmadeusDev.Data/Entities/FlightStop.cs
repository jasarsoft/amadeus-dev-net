using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class FlightStop
    {
        //iataCode(string, optional) : IATA airline codes ,
        //newAircraft(AircraftEquipment, optional),
        //duration(string, optional) : stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g.PT2H10M ,
        //arrivalAt(string, optional) : arrival at the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00 ,
        //departureAt(string, optional) : departure from the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        public string iataCode { get; set; }
        public AircraftEquipment newAircraft { get; set; }
        public string duration { get; set; }
        public string arrivalAt { get; set; }
        public string departureAt { get; set; }
    }
}
