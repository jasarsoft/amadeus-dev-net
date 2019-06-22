using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Service
    {
        //segments (Array[Segment], optional)
        public List<Segment> segments { get; set; }
    }
}
