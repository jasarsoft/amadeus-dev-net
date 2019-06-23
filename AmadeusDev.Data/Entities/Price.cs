﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }

        public string Total { get; set; }
        public string TotalTaxes { get; set; }
    }
}
