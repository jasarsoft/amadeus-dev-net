using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Issue_Source
    {
        //pointer(string, optional) : a JSON Pointer[RFC6901] to the associated entity in the request document ,
        //parameter(string, optional) : a string indicating which URI query parameter caused the issue ,
        //example(string, optional) : a string indicating an example of the right value
        public string pointer { get; set; }
        public string parameter { get; set; }
        public string example { get; set; }
    }
}
