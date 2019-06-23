using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class DictionaryEntry
    {
        [Key]
        public int DictionaryEntryId { get; set; }

        [Required]
        public string Code { get; set; }  //code (string)
    }
}
