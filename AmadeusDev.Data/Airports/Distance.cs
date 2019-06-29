using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Distances", Schema = "Airport")]
    public class Distance
    {
        [Key]
        public int DistanceId { get; set; }

        public int Value { get; set; }
        public string Unit { get; set; }
    }
}
