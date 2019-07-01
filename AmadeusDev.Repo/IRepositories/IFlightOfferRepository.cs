using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightOfferRepository : IRepository<FlightOffer, int>
    {
        FlightOffer GetById(string id);
        IEnumerable<FlightOffer> GetByFlightId(int flightId);

        int Insert(FlightOffer model);
        IEnumerable<FlightOffer> SortAndGetRange<TKey>(int flightId, int start, int take, Expression<Func<FlightOffer, TKey>> predicate, OrderBy order);
    }
}
