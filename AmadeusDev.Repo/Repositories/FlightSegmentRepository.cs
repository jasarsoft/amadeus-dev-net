using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class FlightSegmentRepository : Repository<FlightSegment, int>, IFlightSegmentRepository
    {
        public FlightSegmentRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(FlightSegment model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.FlightSegmentId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightSegment", e);
                }
            }
        }

        #region Get Departure
        public IEnumerable<FlightSegment> GetByDepartureByIata(string code)
        {
            var query = entity.Include(x => x.Departure)
                .Include(x => x.Arrival)

                .Include(x => x.Aircraft);
                //.Where(x => x.Departure.IataCode.ToLower().Contains(code.ToLower()));

            return query.ToList();
        }

        public async Task<IEnumerable<FlightSegment>> GetByDepartureByIataAsync(string code)
        {
            var query = entity.Include(x => x.Departure)
                .Include(x => x.Arrival)
                //.Include(x => x.Operating)
                .Include(x => x.Aircraft);
                //.Where(x => x.Departure.IataCode.ToLower().Contains(code.ToLower()));

            return await query.ToListAsync();
        }
        #endregion

        #region Get Arrival
        public IEnumerable<FlightSegment> GetByArrivalIata(string code)
        {
            var query = entity.Include(x => x.Aircraft)
                .Include(x => x.Arrival)
                .Include(x => x.Departure);
                //.Include(x => x.Operating)
                //.Where(x => x.Arrival.IataCode.ToLower().Contains(code.ToLower()));

            return query.ToList();
        }

        public async Task<IEnumerable<FlightSegment>> GetByArrivalIataAsync(string code)
        {
            var query = entity.Include(x => x.Aircraft)
                .Include(x => x.Arrival)
                .Include(x => x.Departure);
                //.Include(x => x.Operating)
                //.Where(x => x.Arrival.IataCode.ToLower().Contains(code.ToLower()));

            return await query.ToListAsync();
        }
        #endregion

        #region Get by Date
        public IEnumerable<FlightSegment> GetFlightSegmentsByDate(string date)
        {
            var query = entity.Include(x => x.Aircraft)
                .Include(x => x.Arrival)
                .Include(x => x.Departure);
                //.Include(x => x.Operating)
                //.Where(x => x.Arrival.IataCode.ToLower().Contains(date.ToLower()));

            return query.ToList();
        }
        #endregion

    }
}
