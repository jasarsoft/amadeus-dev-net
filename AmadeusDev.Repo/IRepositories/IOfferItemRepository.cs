using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IOfferItemRepository : IRepository<OfferItem, int>
    {
        IEnumerable<OfferItem> GetByFlightOfferId(int flightOfferId);
    }
}
