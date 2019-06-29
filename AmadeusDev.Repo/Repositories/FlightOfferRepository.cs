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
    public class FlightOfferRepository : Repository<FlightOffer, int>, IFlightOfferRepository
    {
        public FlightOfferRepository(AmadeusDevContext context) : base(context) { }

        public IEnumerable<FlightOffer> GetByFlightId(int flightId)
        {
            var query = entity.Where(x => x.FlightId == flightId);

            return query.ToList();
        }
    }
}
