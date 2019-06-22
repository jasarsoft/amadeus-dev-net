using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class FlightOffer
    {
        //type(string, optional) : the resource name ,
        //id(string, optional) : the resource identifier ,
        //offerItems(Array[OfferItem], optional)
        public string type { get; set; }
        public string id { get; set; }
        public List<OfferItem> offerItems { get; set; }
    }
}
