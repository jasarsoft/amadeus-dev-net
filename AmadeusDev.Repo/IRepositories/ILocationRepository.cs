using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airport;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ILocationRepository : IRepository<Location, int>
    {
        IEnumerable<Location> GetLocationsByName(string keyword);
    }
}
