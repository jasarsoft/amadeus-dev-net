using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flight
{
    [Table("FlightOffers", Schema = "Flight")]
    public class FlightOffer
    {
        [Key]
        public int FlightOfferId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } //the resource identifier
        public string Type { get; set; } //the resource name
        
        public ICollection<OfferItem> OfferItems { get; set; }
    }
}
