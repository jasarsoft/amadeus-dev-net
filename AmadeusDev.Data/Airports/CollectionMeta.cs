using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("CollectionMeta", Schema = "Airports")]
    public class CollectionMeta
    {
        [Key]
        public int MetaId { get; set; }

        public int Count { get; set; }

        [ForeignKey(nameof(Links))]
        public int? LinksId { get; set; }
        virtual public CollectionLinks Links { get; set; }
    }
}
