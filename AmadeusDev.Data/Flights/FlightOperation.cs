using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightOperations", Schema = "Flight")]
    public class FlightOperation
    {
        [Key]
        public int FlightOperationId { get; set; }

        public string Number { get; set; }

        [ForeignKey(nameof(Carrier))]
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    } 
}
