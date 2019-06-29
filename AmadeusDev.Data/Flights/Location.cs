using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Locations", Schema = "Flight")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Code { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
