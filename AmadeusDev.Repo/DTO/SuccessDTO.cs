using System;
using System.Collections.Generic;
using Jasarsoft.AmadeusDev.Data.Airports;

namespace Jasarsoft.AmadeusDev.Repo.DTO
{
    public class SuccessDTO
    {
        public int SuccessId { get; set; }

        public int? MetaId { get; set; }
        virtual public CollectionMeta Meta { get; set; }

        public List<Location> Data { get; set; }

        public int SelfId { get; set; }
        public Self Self { get; set; }
    }
}
