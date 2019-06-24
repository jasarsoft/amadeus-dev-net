using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flights
{
    [Table("Issue", Schema = "Flights")]
    public class Issue
    {
        [Key]
        public int IssueId { get; set; }

        public int? Status { get; set; } //the HTTP status code applicable to this error
        public int? Code { get; set; } //an application-specific error code
        public string Title { get; set; } //a short summary of the error
        public string Detail { get; set; } //explanation of the error

        [ForeignKey(nameof(Source))]
        public int? SourceId { get; set; }
        public virtual IssueSource Source { get; set; } //an object containing references to the source of the error
    }
}
