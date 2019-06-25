using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("DictionaryEntry", Schema = "Flights")]
    public class DictionaryEntry
    {
        [Key]
        public int DictionaryEntryId { get; set; }

        public string Code { get; set; }  //code (string)
    }
}
