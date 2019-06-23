using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class LocationEntry
    {        
        [Key]
        public int LocationEntryId { get; set; }

        [Required]
        public string Key { get; set; } //key (string)
    }
}
