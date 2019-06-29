using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flight
{
    [Table("Carriers", Schema = "Flight")]
    public class Carrier
    {
        [Key]
        public int CarrierId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
