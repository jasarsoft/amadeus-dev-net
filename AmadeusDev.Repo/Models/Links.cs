using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Repo.Models.Flights
{
    [Table("Links", Schema = "Flights")]
    public class Links
    {
        [Key]
        public int LinkId { get; set; }

        public string Self { get; set; }
    }
}
