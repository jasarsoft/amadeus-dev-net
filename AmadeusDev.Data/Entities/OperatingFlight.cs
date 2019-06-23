using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class OperatingFlight
    {
        [Key]
        public int OperatingFlightId { get; set; }

        public string CarrierCode { get; set; } //providing the airline / carrier code
        public string Number { get; set; } //the flight number as assigned by the carrier
    } 
}
