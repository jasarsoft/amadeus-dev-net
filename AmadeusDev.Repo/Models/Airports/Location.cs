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
    }
}
