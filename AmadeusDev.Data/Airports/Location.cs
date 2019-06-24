using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Location", Schema = "Airports")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Id { get; set; } //id of the ressource

        [ForeignKey(nameof(Self))]
        public int? SelfId { get; set; }
        virtual public Self Self { get; set; }

        public string Type { get; set; } //the resource name
        public string SubType { get; set; } //location sub type = ['AIRPORT', 'CITY']
        public string Name { get; set; } //short name of the location
        public string DetailedName { get; set; } //detailed name of the location.For a city location it contains city name and country code.For an airport location it contains city name; country code and airport full name,
        public string TimeZoneOffset { get; set; } //timezone offset of the location at the date of the API call(including daylight saving time) ,
        public string IataCode { get; set; } //IATA code of the location. (IATA table codes here)

        [ForeignKey(nameof(GeoCode))]
        public int? GeoCodeId { get; set; }
        virtual public GeoCode GeoCode { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }
        virtual public Address Address { get; set; }

        [ForeignKey(nameof(Distance))]
        public int? DistanceId { get; set; }
        virtual public Distance Distance { get; set; }

        [ForeignKey(nameof(Analytics))]
        public int? AnalyticsId { get; set; }
        virtual public Analytics Analytics { get; set; }

        public decimal? Relevance { get; set; } //score value calculated based on distance and analytics
    }
}
