using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Currencies", Schema = "Flight")]
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
