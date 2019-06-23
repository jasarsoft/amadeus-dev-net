using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class IssueSource
    {
        [Key]
        public int IssueSourceId { get; set; }

        public string Pointer { get; set; } //a JSON Pointer[RFC6901] to the associated entity in the request document
        public string Parameter { get; set; } //a string indicating which URI query parameter caused the issue
        public string Example { get; set; } //a string indicating an example of the right value
    }
}
