﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Carriers", Schema = "Flight")]
    public class Carrier
    {
        [Key]
        public int CarrierId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
