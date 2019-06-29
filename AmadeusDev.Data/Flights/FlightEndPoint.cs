using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightEndPoints", Schema = "Flight")]
    public class FlightEndPoint
    {
        [Key]
        public int FlightEndPointId { get; set; }

        public string IataCode { get; set; } //IATA airline codes
        public string Terminal { get; set; }  //terminal name / number
        public string At { get; set; }  //local date and time in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
    }
}
