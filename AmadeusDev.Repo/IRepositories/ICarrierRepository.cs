using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ICarrierRepository : IRepository<Carrier, int>
    {
        Carrier FindByCode(string code);
        Carrier FindByCode(Carrier carrier);

        int Insert(KeyValuePair<string, string> model);

        Task<Carrier> FindByCodeAsync(string code);
        Task<Carrier> FindByCodeAsync(Carrier carrier);

        Task<int> InsertAsync(KeyValuePair<string, string> model);
    }
}
