using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Addresses", Schema = "Airport")]
    public class Address
    {
        [Key]
        public int AdressId { get; set; }

        public string CityName { get; set; } //name of the city of the location; equal to name if the location is a city,
        public string CityCode { get; set; } //IATA code of the city of the location; equal to IATAcode if the location is a city,
        public string CountryName { get; set; } //name of the country of the location ,
        public string CountryCode { get; set; } //code of the country of the location in ISO standard,
        public string StateCode { get; set; } //code of the state of the location if any ,
        public string RegionCode { get; set; } //code of the region of the location in ISO standard
    }
}
