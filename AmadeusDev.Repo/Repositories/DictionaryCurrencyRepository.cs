using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class DictionaryCurrencyRepository : Repository<DictionaryCurrency, int>, IDictionaryCurrencyRepository
    {
        public DictionaryCurrencyRepository(AmadeusDevContext context) : base(context) { }


    }
}
