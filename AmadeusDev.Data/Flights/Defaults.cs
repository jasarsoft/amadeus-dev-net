using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Defaults", Schema = "Flights")]
    public class Defaults
    {
        [Key]
        public int DefaultId { get; set; }

        public bool? NonStop { get; set; } //search finds only direct flights going from the origin to the destination with no stop
        public int? Adults { get; set; } //search does the computation for one adult
    }
}
