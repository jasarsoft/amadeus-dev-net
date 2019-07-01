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

        public string Origin { get; set; }
        public string Destination { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public string Link { get; set; }
        
        public ICollection<FlightOffer> Data { get; set; }
    }
}
