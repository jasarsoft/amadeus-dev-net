using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Flights", Schema = "Flight")]
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        public ICollection<FlightOffer> Data { get; set; }

        [ForeignKey(nameof(Dictionary))]
        public int DictionariesId { get; set; }
        public Dictionary Dictionary { get; set; }
    }
}
