using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Self", Schema = "Airports")]
    public class Self
    {
        [Key]
        public int SelfId { get; set; }

        public string Href { get; set; }
        public ICollection<String> Methods { get; set; }
        public int Count { get; set; }
    }
}
