using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ICurrencyRepository : IRepository<Currency, int>
    {
        int Insert(KeyValuePair<string, string> model);
        Currency FindByCode(Currency currency);
        Currency FindByCode(string code);
    }
}
