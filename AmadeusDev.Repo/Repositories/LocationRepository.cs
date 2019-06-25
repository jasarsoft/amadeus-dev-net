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
    public class LocationRepository : Repository<Location, int>, ILocationRepository
    {
        public LocationRepository(AmadeusDevContext context) : base(context) { }

        
        public IEnumerable<Location> GetLocationsByName(string keyword)
        {
            var query = entity.Where(x => x.Name.ToLower().Contains(keyword));

            return query.ToList();
        }
    }
}
