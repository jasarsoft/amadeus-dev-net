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
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class FlightOfferRepository : Repository<FlightOffer, int>, IFlightOfferRepository
    {
        public FlightOfferRepository(AmadeusDevContext context) : base(context) { }


        public int Count(int flightId)
        {
            return entity.Where(x => x.FlightId == flightId).Count();
        }

        public async Task<int> CountAsync(int flightId)
        {
            return await entity.Where(x => x.FlightId == flightId).CountAsync();
        }

        public FlightOffer GetById(string id) => entity.Where(x => x.Id == id).FirstOrDefault();

        public async Task<FlightOffer> GetByIdAsync(string id) => await entity.Where(x => x.Id == id).FirstOrDefaultAsync();

        public IEnumerable<FlightOffer> GetByFlightId(int flightId) => entity.Where(x => x.FlightId == flightId).ToList();

        public async Task<IEnumerable<FlightOffer>> GetByFlightIdAsync(int flightId) => await entity.Where(x => x.FlightId == flightId).ToListAsync();


        public int Insert(FlightOffer model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.FlightOfferId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightOffer", e);
                }
            }
        }

        public async Task<int> InsertAsync(FlightOffer model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.AddAsync(model);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return model.FlightOfferId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightOffer Async", e);
                }
            }
        }

        public override IEnumerable<FlightOffer> SortAndGetRange<TKey>(int start, int take, Expression<Func<FlightOffer, TKey>> predicate, OrderBy order)
        {
            return order == OrderBy.ASC
                ? entity.AsNoTracking()
                    .OrderBy(predicate)
                    .Skip(start).Take(take)
                    .ToList()
                : entity.AsNoTracking()
                    .OrderByDescending(predicate)
                    .Skip(start).Take(take)
                    .ToList();
        }

        public IEnumerable<FlightOffer> SortAndGetRange<TKey>(int flightId, int start, int take, Expression<Func<FlightOffer, TKey>> predicate, OrderBy order)
        {
            return order == OrderBy.ASC
                ? entity.AsNoTracking()
                    .Where(x => x.FlightId == flightId)
                    .OrderBy(predicate)
                    .Skip(start).Take(take)
                    .ToList()
                : entity.AsNoTracking()
                    .Where(x => x.FlightId == flightId)
                    .OrderByDescending(predicate)
                    .Skip(start).Take(take)
                    .ToList();
        }

        public async Task<IEnumerable<FlightOffer>> SortAndGetRangeAsync<TKey>(int flightId, int start, int take, Expression<Func<FlightOffer, TKey>> predicate, OrderBy order)
        {
            return order == OrderBy.ASC
                ? await entity.AsNoTracking()
                    .Where(x => x.FlightId == flightId)
                    .OrderBy(predicate)
                    .Skip(start).Take(take)
                    .ToListAsync()
                : await entity.AsNoTracking()
                    .Where(x => x.FlightId == flightId)
                    .OrderByDescending(predicate)
                    .Skip(start).Take(take)
                    .ToListAsync();
        }
    }
}
