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
    public class OfferItemRepository : Repository<OfferItem, int>, IOfferItemRepository
    {
        public OfferItemRepository(AmadeusDevContext context) : base(context) { }


        public IEnumerable<OfferItem> GetByFlightOfferId(int flightOfferId)
        {
            return entity.Include(x => x.Price)
                .Include(x => x.PricePerAdult)
                .Include(x => x.PricePerChild)
                .Include(x => x.PricePerInfant)
                .Include(x => x.PricePerSenior)
                .Where(x => x.FlightOfferId == flightOfferId)
                .ToList();
        }

        public int Insert(OfferItem model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.OfferItemId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert OfferItem", e);
                }
            }
        }
    }
}
