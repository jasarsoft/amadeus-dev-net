using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class FlightEndPoint
    {
        //iataCode(string, optional) : IATA airline codes ,
        //terminal(string, optional) : terminal name / number ,
        //at(string, optional) : local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        public string iataCode { get; set; }
        public string terminal { get; set; }
        public string at { get; set; }
    }
}
