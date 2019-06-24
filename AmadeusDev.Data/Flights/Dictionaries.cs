using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Dictionaries", Schema = "Flights")]
    public class Dictionaries
    {
        [Key]
        public int DictionaryId { get; set; }

        [ForeignKey(nameof(Carriers))]
        public int? CarriersId { get; set; }
        public virtual DictionaryEntry Carriers { get; set; }

        [ForeignKey(nameof(Currencies))]
        public int? CurrenciesId { get; set; }
        public virtual DictionaryEntry Currencies { get; set; }

        [ForeignKey(nameof(Aircraft))]
        public int? AircraftId { get; set; }
        public virtual DictionaryEntry Aircraft { get; set; }

        [ForeignKey(nameof(Locations))]
        public int? LocationsId { get; set; }
        public virtual LocationEntry Locations { get; set; }
    }
}
