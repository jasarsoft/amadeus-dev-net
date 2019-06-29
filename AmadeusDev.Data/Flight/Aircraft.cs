using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flight
{
    [Table("Aircrafts", Schema = "Flight")]
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
