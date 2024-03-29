﻿using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Airports
{
    public class Address
    {
        public string CityName { get; set; } 
        public string CityCode { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string RegionCode { get; set; } 


        public static implicit operator Data.Airports.Address(Address model)
        {
            return new Data.Airports.Address
            {
                CityCode = model.CityCode,
                CityName = model.CityName,
                CountryCode = model.CountryCode,
                CountryName = model.CountryName,
                RegionCode = model.RegionCode,
                StateCode = model.StateCode,
            };
        }
    }
}
