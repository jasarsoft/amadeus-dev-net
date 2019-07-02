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
    public class ServiceRepository : Repository<Service, int>, IServiceRepository
    {
        public ServiceRepository(AmadeusDevContext context) : base(context) { }


        public IEnumerable<Service> GetByOfferItemId(int offerItemId) => entity.Where(x => x.OfferItemId == offerItemId).ToList();

        public async Task<IEnumerable<Service>> GetByOfferItemIdAsync(int offerItemId) => await entity.Where(x => x.OfferItemId == offerItemId).ToListAsync();

        public int Insert(Service model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.ServiceId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Service", e);
                }
            }
        }

        public async Task<int> InsertAsync(Service model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.AddAsync(model);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return model.ServiceId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Service Async", e);
                }
            }
        }
    }
}
