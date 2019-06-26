using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    public class Issue
    {
        public int? Status { get; set; } 
        public int? Code { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; } 
        public IssueSource Source { get; set; }
    }
}
