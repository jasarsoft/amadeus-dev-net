using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Distance", Schema = "Airports")]
    public class Distance
    {
        [Key]
        public int DistanceId { get; set; }

        public int? Value { get; set; } //great-circle distance between two locations.This distance thus do not take into account traffic conditions; international boundaries; mountains; water; or other elements that might make the a nearby location hard to reach. ,
        public string Unit { get; set; } //unit of the distance = ['KM']
    }
}
