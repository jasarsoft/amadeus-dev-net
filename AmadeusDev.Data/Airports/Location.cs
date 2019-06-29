using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Locations", Schema = "Airport")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; } 
        public string DetailedName { get; set; } 
        public string TimeZoneOffset { get; set; }
        public string IataCode { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Score { get; set; }
        public decimal? Relevance { get; set; }
        public string Href { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        virtual public Address Address { get; set; }

        [ForeignKey(nameof(Distance))]
        public int? DistanceId { get; set; }
        public virtual Distance Distance { get; set; }
    }
}
