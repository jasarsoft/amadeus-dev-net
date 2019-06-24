using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jasarsoft.AmadeusDev.Data.Airports
{
    [Table("Success", Schema = "Airports")]
    public class Success
    {        
        [Key]
        public int SuccessId { get; set; }

        [ForeignKey(nameof(Meta))]
        public int? MetaId { get; set; }
        virtual public CollectionMeta Meta { get; set; }

        public ICollection<Location> Data { get; set; }        
    }
}
