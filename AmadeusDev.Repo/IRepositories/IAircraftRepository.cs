using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IAircraftRepository : IRepository<Aircraft, int>
    {
        Aircraft FindByCode(string code);
        Aircraft FindByCode(Aircraft aircraft);

        int Insert(KeyValuePair<string, string> model);

        Task<Aircraft> FindByCodeAsync(string code);
        Task<Aircraft> FindByCodeAsync(Aircraft aircraft);

        Task<int> InsertAsync(KeyValuePair<string, string> model);
    }
}
