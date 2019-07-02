using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ILocationRepository : IRepository<Location, int>
    {
        Location FindByCode(string code);
        Location FindByCode(Location location);

        int Insert(KeyValuePair<string, string> model);


        Task<Location> FindByCodeAsync(string code);
        Task<Location> FindByCodeAsync(Location location);

        Task<int> InsertAsync(KeyValuePair<string, string> model);
    }
}
