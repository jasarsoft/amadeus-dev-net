using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("GeoCode", Schema = "Airports")]
    public class GeoCode
    {
        [Key]
        public int GeoCodeId { get; set; }

        public decimal? Latitude { get; set; } //latitude of the location
        public decimal? Longitude { get; set; } //longitude of the location
    }
}
