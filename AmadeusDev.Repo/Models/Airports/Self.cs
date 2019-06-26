using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Airports
{
    public class Self
    {
        public string Href { get; set; }
        public ICollection<String> Methods { get; set; }
        public int Count { get; set; }
    }
}
