using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Dictionaries
    {
        //carriers(DictionaryEntry, optional),
        //currencies(DictionaryEntry, optional),
        //aircraft(DictionaryEntry, optional),
        //locations(LocationEntry, optional)
        public DictionaryEntry carriers { get; set; }
        public DictionaryEntry currencies { get; set; }
        public DictionaryEntry aircraft { get; set; }
        public LocationEntry locations { get; set; }
    }
}
