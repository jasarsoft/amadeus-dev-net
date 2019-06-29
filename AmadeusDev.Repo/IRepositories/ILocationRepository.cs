using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airports;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ILocationRepository : IRepository<Location, int>
    {
        IEnumerable<Location> GetLocationsByName(string keyword);

        void Insert(Models.Airports.Location model);
    }
}
