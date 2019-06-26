using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class ServiceRepository : Repository<Service, int>, IServiceRepository
    {
        public ServiceRepository(AmadeusDevContext context) : base(context) { }

        public IEnumerable<Service> GetByOfferItemId(int offerItemId)
        {
            var query = entity.Where(x => x.OfferItemId == offerItemId);

            return query.ToList();
        }
    }
}
