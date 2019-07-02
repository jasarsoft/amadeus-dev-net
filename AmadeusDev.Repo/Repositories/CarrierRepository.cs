using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class CarrierRepository : Repository<Carrier, int>, ICarrierRepository
    {
        public CarrierRepository(AmadeusDevContext context) : base(context) { }


        public Carrier FindByCode(string code)
        {
            return entity.Where(x => x.Code == code).FirstOrDefault();
        }

        public async Task<Carrier> FindByCodeAsync(string code)
        {
            return await entity.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public Carrier FindByCode(Carrier carrier)
        {
            return base.Where(x => x.Code == carrier.Code).FirstOrDefault();
        }

        public async Task<Carrier> FindByCodeAsync(Carrier carrier)
        {
            return await entity.Where(x => x.Code == carrier.Code).FirstOrDefaultAsync();
        }

        public int Insert(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Carrier carrier = new Carrier
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    context.Add(carrier);
                    context.SaveChanges();
                    transaction.Commit();
                    return carrier.CarrierId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Carrier", e);
                }
            }
        }

        public async Task<int> InsertAsync(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    Carrier carrier = new Carrier
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    await context.AddAsync(carrier);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return carrier.CarrierId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Carrier Async", e);
                }
            }
        }
    }
}
