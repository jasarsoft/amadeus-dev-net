using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("LocationEntry", Schema = "Flights")]
    public class LocationEntry
    {        
        [Key]
        public int LocationEntryId { get; set; }

        public string Key { get; set; } //key (string)
    }
}
