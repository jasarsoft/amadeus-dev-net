using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("OfferItems", Schema = "Flight")]
    public class OfferItem
    {
        [Key]
        public int OfferItemId { get; set; }

        public ICollection<Service> Services { get; set; } 

        [ForeignKey(nameof(Price))]
        public int PriceId { get; set; }
        public Price Price { get; set; }

        [ForeignKey(nameof(PricePerAdult))]
        public int? PricePerAdultId { get; set; }
        public virtual Price PricePerAdult { get; set; }

        [ForeignKey(nameof(PricePerInfant))]
        public int? PricePerInfantId { get; set; }
        public virtual Price PricePerInfant { get; set; }

        [ForeignKey(nameof(PricePerChild))]
        public int? PricePerChildId { get; set; }
        public virtual Price PricePerChild { get; set; }

        [ForeignKey(nameof(PricePerSenior))]
        public int? PricePerSeniorId { get; set; }
        public virtual Price PricePerSenior { get; set; }


        [ForeignKey(nameof(FlightOffer))]
        public int FlightOfferId { get; set; }
        public FlightOffer FlightOffer { get; set; }
    }
}
