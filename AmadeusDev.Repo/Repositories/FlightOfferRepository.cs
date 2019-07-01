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


        public FlightOffer GetById(string id) => entity.Where(x => x.Id == id).FirstOrDefault();
        
        public IEnumerable<FlightOffer> GetByFlightId(int flightId) => entity.Where(x => x.FlightId == flightId).ToList();
        

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
    }
}
