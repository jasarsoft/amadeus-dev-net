using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class FlightOffers
    {
        //data(Array[FlightOffer], optional),
        //dictionaries(Dictionaries, optional),
        //meta(Meta, optional),
        //warnings(Array[Issue], optional)
        public List<FlightOffer> data { get; set; }
        public Dictionaries dictionaries { get; set; }
        public Meta meta { get; set; }
        public List<Issue> warnings { get; set; }
    }
}
