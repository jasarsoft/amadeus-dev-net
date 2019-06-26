using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IServiceRepository : IRepository<Service, int>
    {
        IEnumerable<Service> GetByOfferItemId(int offerItemId);
    }
}
