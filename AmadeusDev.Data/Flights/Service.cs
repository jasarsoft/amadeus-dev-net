using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Services", Schema = "Flight")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        public ICollection<Segment> Segments { get; set; }

       
        [ForeignKey(nameof(OfferItem))]
        public int OfferItemId { get; set; }
        public OfferItem OfferItem { get; set; }
    }
}
