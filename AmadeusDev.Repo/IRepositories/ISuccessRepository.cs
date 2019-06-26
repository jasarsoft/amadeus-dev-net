using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airports;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ISuccessRepository : IRepository<Success, int>
    {
        void InsertSuccess(Success model);
        Task<int> InsertSuccessAsync(Success model);
        
        IEnumerable<Success> GetAndSortWithFilters<TKey>(int start, int take, Expression<Func<Success, TKey>> predicate, OrderBy order, string departure, string arrival);
    }
}
