using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class Dictionaries
    {
        public Dictionary<string, string> Carriers { get; set; }
        public Dictionary<string, string> Currencies { get; set; }
        public Dictionary<string, string> Aircraft { get; set; }
        public Dictionary<string, LocationEntry> Locations { get; set; }
    }
}
