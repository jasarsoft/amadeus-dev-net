using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class OperatingFlight
    {
        //carrierCode(string, optional) : providing the airline / carrier code,
        //number (string, optional): the flight number as assigned by the carrier
        public string carrierCode { get; set; }
        public string number { get; set; }
    } 
}
