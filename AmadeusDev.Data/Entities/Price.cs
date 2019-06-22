using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Price
    {
        //total(string, optional),
        //totalTaxes(string, optional)  
        public string total { get; set; }
        public string totalTaxes { get; set; }
    }
}
