using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Airports
{
    public class Location
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public string Name { get; set; }
        public string DetailedName { get; set; }
        public string TimeZoneOffset { get; set; }
        public string IataCode { get; set; }
        public decimal? Relevance { get; set; }

        public Self Self { get; set; }
        public GeoCode GeoCode { get; set; }
        public Address Address { get; set; }
        public Analytics Analytics { get; set; }
        public Distance Distance { get; set; }


        public static implicit operator Data.Airports.Location(Models.Airports.Location model)
        {
            return new Data.Airports.Location
            {
                Address = new Data.Airports.Address
                {
                    CityCode = model.Address.CityCode,
                    CityName = model.Address.CityName,
                    CountryCode = model.Address.CountryCode,
                    CountryName = model.Address.CountryName,
                    RegionCode = model.Address.RegionCode,
                    StateCode = model.Address.StateCode,
                },
                DetailedName = model.DetailedName,
                Distance = new Data.Airports.Distance
                {
                    Unit = model.Distance.Unit,
                    Value = model.Distance.Value,
                },
                Href = model.Self.Href,
                IataCode = model.IataCode,
                Id = model.Id,
                Latitude = model.GeoCode.Latitude,
                Longitude = model.GeoCode.Longitude,
                Name = model.Name,
                Relevance = model.Relevance,
                Score = model.Analytics.Travelers.Score,
                TimeZoneOffset = model.TimeZoneOffset,
                Type = model.Type,
            };
        }
    }
}
