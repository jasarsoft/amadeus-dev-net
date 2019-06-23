using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Entities
{
    public class Links
    {
        [Key]
        public int LinkId { get; set; }

        public string Self { get; set; }
    }
}
