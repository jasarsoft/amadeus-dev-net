using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.DTO;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class FlightOffersRepository : Repository<FlightOffers, int>, IFlightOffersRepository
    {
        public FlightOffersRepository(AmadeusDevContext context) : base(context) { }


        public IEnumerable<FlightDTO> GetFlights(int start, int take, OrderBy order, string column, string departureSearch, string arrivalSearch)
        {
            var query = context.FlightOffers
                .Include(x => x.Data)

                .Include(x => x.Dictionaries)
                    .ThenInclude(y => y.Aircraft)

                .Include(x => x.Meta)
                .Include(x => x.Data)
                .Skip(start).Take(take);

            return query.Select(x => new FlightDTO
            {
                Departure = x.DictionariesId.ToString(),
            });
        }
    }
}
