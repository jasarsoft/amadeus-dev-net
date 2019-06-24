using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("CollectionLinks", Schema = "Airports")]
    public class CollectionLinks
    {
        [Key]
        public int LinksId { get; set; }

        public string Self { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string Last { get; set; }
        public string First { get; set; }
        public string Up { get; set; }
    }
}
