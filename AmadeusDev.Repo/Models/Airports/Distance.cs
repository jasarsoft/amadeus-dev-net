using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Airports
{
    public class Distance
    {
        public int? Value { get; set; } 
        public string Unit { get; set; } 


        public static implicit operator Data.Airports.Distance(Models.Airports.Distance model)
        {
            return new Data.Airports.Distance
            {
                Unit = model.Unit,
                Value = model.Value,
            };
        }
    }
}
