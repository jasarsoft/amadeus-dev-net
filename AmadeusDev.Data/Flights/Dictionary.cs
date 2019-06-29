using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Dictionaries", Schema = "Flight")]
    public class Dictionary
    {
        [Key]
        public int DictionaryId { get; set; }

        public ICollection<DictionaryCarrier> DictionaryCarriers { get; set; }
        public ICollection<DictionaryCurrency> DictionaryCurrencies { get; set; }   
        public ICollection<DictionaryAircraft> DictionaryAircrafts { get; set; }
        public ICollection<DictionaryLocation> DictionaryLocations { get; set; }
    }
}
