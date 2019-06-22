using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Issue
    {
        //status(integer, optional) : the HTTP status code applicable to this error ,
        //code(integer, optional) : an application-specific error code ,
        //title(string, optional) : a short summary of the error ,
        //detail(string, optional) : explanation of the error,
        //source (Issue_Source, optional): an object containing references to the source of the error
        public int status { get; set; }
        public int code { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public Issue_Source source { get; set; }
    }
}
