using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightOffer", Schema = "Flights")]
    public class FlightOffer
    {
        [Key]
        public int FlightOfferId { get; set; }

        [ForeignKey(nameof(FlightOffers))]
        public int? FlightOffersId { get; set; }
        public virtual FlightOffers FlightOffers { get; set; }

        public string Type { get; set; } //the resource name
        public string Id { get; set; } //the resource identifier

        public ICollection<OfferItem> OfferItems { get; set; }
    }
}
