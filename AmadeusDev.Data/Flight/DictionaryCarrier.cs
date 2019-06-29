using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Flight
{
    [Table("DictionaryCarriers", Schema = "Flight")]
    public class DictionaryCarrier
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DictionaryId { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarrierId { get; set; }
    }
}
