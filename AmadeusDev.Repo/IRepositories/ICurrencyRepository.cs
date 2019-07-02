using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ICurrencyRepository : IRepository<Currency, int>
    {
        Currency FindByCode(string code);
        Currency FindByCode(Currency currency);

        int Insert(KeyValuePair<string, string> model);

        Task<Currency> FindByCodeAsync(string code);
        Task<Currency> FindByCodeAsync(Currency currency);

        Task<int> InsertAsync(KeyValuePair<string, string> model);

    }
}
