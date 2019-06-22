using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class OfferItem
    {
        //services(Array[Service], optional),
        //price(Price, optional),
        //pricePerAdult(Price, optional),
        //pricePerInfant(Price, optional),
        //pricePerChild(Price, optional),
        //pricePerSenior(Price, optional)
        public List<Service> services { get; set; }
        public Price price { get; set; }
        public Price pricePerAdult { get; set; }
        public Price pricePerInfant { get; set; }
        public Price pricePerChild { get; set; }
        public Price pricePerSenior { get; set; }
    }
}
