﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public ICollection<Segment> Segments { get; set; }
    }
}
