using System;
using System.Collections.Generic;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo;

namespace Jasarsoft.AmadeusDev.Repo.DTO
{
    public class AirportDTO
    {
        public Location Location { get; set; }


        public static implicit operator AirportDTO(Data.Airports.Location model)
        {
            return new AirportDTO
            {
                Location = model,
            };
        }

        //public static implicit operator AirportDTO(Models.Airports.Location model)
        //{
        //    return new AirportDTO
        //    {
        //        Location = new Location
        //        {
        //            Address = new Address
        //            {
        //                CityCode = model.Address.CityCode,
        //                CityName = model.Address.CityName,
        //                CountryCode = model.Address.CountryCode,
        //                CountryName = model.Address.CountryName,
        //                RegionCode = model.Address.RegionCode,
        //                StateCode = model.Address.StateCode,
        //            },
        //            DetailedName = model.DetailedName,
        //            Distance = new Distance
        //            {
        //                Unit = model.Distance.Unit,
        //                Value = model.Distance.Value,
        //            },
        //            Href = model.Self.Href,
        //            IataCode = model.IataCode,
        //            Id = model.Id,
        //            Latitude = model.GeoCode.Latitude,
        //            Longitude = model.GeoCode.Longitude,
        //            Name = model.Name,
        //            Relevance = model.Relevance,
        //            Score = model.Analytics.Travelers.Score,
        //            TimeZoneOffset = model.TimeZoneOffset,
        //            Type = model.Type,
        //        }
        //    };
        //}

        //public static implicit operator Data.Airports.Location(AirportDTO model)
        //{
        //    return new Location
        //    {
        //        Address = new Address
        //        {
        //            CityCode = model.Location.Address.CityCode,
        //            CityName = model.Location.Address.CityName,
        //            CountryCode = model.Location.Address.CountryCode,
        //            CountryName = model.Location.Address.CountryName,
        //            RegionCode = model.Location.Address.RegionCode,
        //            StateCode = model.Location.Address.StateCode,
        //        },
        //        DetailedName = model.Location.DetailedName,
        //        Distance = new Distance
        //        {
        //            Unit = model.Location.Distance.Unit,
        //            Value = model.Location.Distance.Value,
        //        },
        //        Href = model.Location.Href,
        //        IataCode = model.Location.IataCode,
        //        Id = model.Location.Id,
        //        Latitude = model.Location.Latitude,
        //        Longitude = model.Location.Longitude,
        //        Name = model.Location.Name,
        //        Relevance = model.Location.Relevance,
        //        Score = model.Location.Score,
        //        TimeZoneOffset = model.Location.TimeZoneOffset,
        //        Type = model.Location.Type,
        //    };
        //}
    }
}
