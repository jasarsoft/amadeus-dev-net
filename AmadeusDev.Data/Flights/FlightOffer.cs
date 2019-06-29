using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("FlightOffers", Schema = "Flight")]
    public class FlightOffer
    {
        [Key]
        public int FlightOfferId { get; set; }

        public string Id { get; set; } //the resource identifier
        public string Type { get; set; } //the resource name

        [ForeignKey(nameof(Flight))]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public ICollection<OfferItem> OfferItems { get; set; }
    }
}
