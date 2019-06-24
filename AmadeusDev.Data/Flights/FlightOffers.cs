using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightOffers", Schema = "Flights")]
    public class FlightOffers
    {
        [Key]
        public int FlightOffersId { get; set; }

        public ICollection<FlightOffer> Data { get; set; }

        [ForeignKey(nameof(Dictionaries))]
        public int? DictionariesId { get; set; }
        public virtual Dictionaries Dictionaries { get; set; }

        [ForeignKey(nameof(Meta))]
        public int? MetaId { get; set; }
        public virtual Meta Meta { get; set; }

        public ICollection<Issue> Warnings { get; set; }
    }
}
