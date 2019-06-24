using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Analytics", Schema = "Airports")]
    public class Analytics
    {
        [Key]
        public int AnalyticsId { get; set; }

        [ForeignKey(nameof(Travelers))]
        public int? TravelersId { get; set; }
        virtual public Travelers Travelers { get; set; }
    }
}
