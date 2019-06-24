using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightStop", Schema = "Flights")]
    public class FlightStop
    {
        [Key]
        public int FlightStopId { get; set; }

        public string IataCode { get; set; } //IATA airline codes

        [ForeignKey(nameof(NewAircraft))]
        public int? NewAircraftId { get; set; }
        public virtual AircraftEquipment NewAircraft { get; set; }

        public string Duration { get; set; } //stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g.PT2H10M
        public string ArrivalAt { get; set; } //arrival at the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
        public string DepartureAt { get; set; } //departure from the stop in ISO8601 YYYY-MM-ddThh:mm±hh:mm format, e.g. 2017-02-10T20:40:00+02:00
    }
}
