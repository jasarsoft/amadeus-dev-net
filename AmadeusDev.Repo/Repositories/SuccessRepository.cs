using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class SuccessRepository : Repository<Success, int>, ISuccessRepository
    {
        public SuccessRepository(AmadeusDevContext context) : base(context) { }

        public override IEnumerable<Success> SortAndGetRange<TKey>(int start, int take, Expression<Func<Success, TKey>> predicate, OrderBy order)
        {
            return order == OrderBy.ASC
                ? entity.Include(x => x.Meta)
                        .ThenInclude(i => i.Links)
                        .Include(x => x.Data)
                        .OrderBy(predicate)
                        .Skip(start)
                        .Take(take)
                : entity.Include(x => x.Meta)
                        .ThenInclude(i => i.Links)
                        .Include(x => x.Data)
                        .OrderBy(predicate)
                        .Skip(start)
                        .Take(take);

        }
    }
}
