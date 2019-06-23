using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Entities;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class DictionaryEntryRespository : Repository<DictionaryEntry, int>, IDictionaryEntryRepository
    {
        public DictionaryEntryRespository(AmadeusDevContext context) : base(context) { }


    }
}
