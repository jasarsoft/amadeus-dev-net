using System;
using System.Collections.Generic;

namespace Jasarsoft.AmadeusDev.Repo.Models.Airports
{
    public class Success
    {        
        public CollectionMeta Meta { get; set; }
        public ICollection<Location> Data { get; set; }        
    }
}
