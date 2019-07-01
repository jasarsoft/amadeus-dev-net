using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightSegments", Schema = "Flight")]
    public class FlightSegment
    {
        [Key]
        public int FlightSegmentId { get; set; }

        [ForeignKey(nameof(Departure))]
        public int DepartureId { get; set; }
        public FlightEndPoint Departure { get; set; }

        [ForeignKey(nameof(Arrival))]
        public int ArrivalId { get; set; }
        public FlightEndPoint Arrival { get; set; }

        public string Number { get; set; }
        public string Duration { get; set; }

        [ForeignKey(nameof(Carrier))]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }

        [ForeignKey(nameof(Aircraft))]
        public int AircraftId { get; set; }
        public Aircraft Aircraft { get; set; }

        [ForeignKey(nameof(Operation))]
        public int OperationId { get; set; }
        public Operation Operation { get; set; }

        public ICollection<FlightStop> Stops { get; set; }  //information regarding the different stops composing the flight segment.E.g.technical stop, change of gauge...
    }
}
