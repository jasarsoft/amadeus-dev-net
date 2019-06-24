using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Travelers", Schema = "Airports")]
    public class Travelers
    {
        [Key]
        public int TravelersId { get; set; }

        public decimal? Score { get; set; } //Approximate score for ranking purposes calculated based on number of travelers in the location.
    }
}
