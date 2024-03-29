﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Aircrafts", Schema = "Flight")]
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
