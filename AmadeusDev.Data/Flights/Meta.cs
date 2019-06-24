using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Meta", Schema = "Flights")]
    public class Meta
    {
        [Key]
        public int MetaId { get; set; }

        [ForeignKey(nameof(Links))]
        public int? LinksId { get; set; }
        public virtual Links Links { get; set; }

        public string Currency { get; set; } //the currency in which the prices of the flight offers are returned.Currency is specified in the ISO 4217 format, e.g.EUR for Euro

        [ForeignKey(nameof(Defaults))]
        public int? DefaultsId { get; set; }
        public virtual Defaults Defaults { get; set; }
    }
}
