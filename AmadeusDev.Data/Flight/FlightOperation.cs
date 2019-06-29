using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flight
{
    [Table("FlightOperations", Schema = "Flight")]
    public class FlightOperation
    {
        [Key]
        public int FlightOperationId { get; set; }

        public string CarrierCode { get; set; } 
        public string Number { get; set; } 
    } 
}
