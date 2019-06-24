using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class SelfRepository : Repository<Self, int>, ISelfRepository
    {
        public SelfRepository(AmadeusDevContext context) : base(context) { }


    }
}
