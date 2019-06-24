using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightSegment", Schema = "Flights")]
    public class FlightSegment
    {
        [Key]
        public int FlightSegmentId { get; set; }

        [ForeignKey(nameof(Departure))]
        public int? DepartureId { get; set; }
        public virtual FlightEndPoint Departure { get; set; }

        [ForeignKey(nameof(Arrival))]
        public int? ArrivalId { get; set; }
        public virtual FlightEndPoint Arrival { get; set; }

        public string CarrierCode { get; set; } //providing the airline / carrier code
        public string Number { get; set; } //the flight number as assigned by the carrier

        [ForeignKey(nameof(Aircraft))]
        public int? AircraftId { get; set; }
        public virtual AircraftEquipment Aircraft { get; set; }

        [ForeignKey(nameof(Operating))]
        public int? OperatingId { get; set; }
        public virtual OperatingFlight Operating { get; set; }

        public string Duration { get; set; } //stop duration in ISO8601 PnYnMnDTnHnMnS format, e.g.PT2H10M

        public ICollection<FlightStop> Stops { get; set; }  //information regarding the different stops composing the flight segment.E.g.technical stop, change of gauge...
    }
}
