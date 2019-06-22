using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Meta
    {
        //links(Links, optional),
        //currency(string, optional) : the currency in which the prices of the flight offers are returned.Currency is specified in the ISO 4217 format, e.g.EUR for Euro ,
        //defaults(Defaults, optional)
        public Links links { get; set; }
        public string currency { get; set; }
        public Defaults defaults { get; set; }
    }
}
