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
    public class FlightOfferRepository : Repository<FlightOffer, int>, IFlightOfferRepository
    {
        public FlightOfferRepository(AmadeusDevContext context) : base(context) { }


        public IEnumerable<FlightOffer> GetByFlightId(int flightId)
        {
            var query = entity.Where(x => x.FlightId == flightId);

            return query.ToList();
        }

        public int Insert(FlightOffer model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var result = GetById(model.Id);

                    if (result == null)
                    {
                        context.Add(model);
                        context.SaveChanges();
                        transaction.Commit();
                        return model.FlightOfferId;
                    }

                    return result.FlightOfferId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightOffer", e);
                }
            }
        }

        public FlightOffer GetById(string id)
        {
            return entity.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
