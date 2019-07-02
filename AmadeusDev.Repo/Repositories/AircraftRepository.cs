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
    public class AircraftRepository : Repository<Aircraft, int>, IAircraftRepository
    {
        public AircraftRepository(AmadeusDevContext context) : base(context) { }


        public Aircraft FindByCode(string code)
        {
            return entity.Where(x => x.Code == code).FirstOrDefault();
        }

        public async Task<Aircraft> FindByCodeAsync(string code)
        {
            return await entity.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public Aircraft FindByCode(Aircraft aircraft)
        {
            return entity.Where(x => x.Code == aircraft.Code).FirstOrDefault();
        }

        public async Task<Aircraft> FindByCodeAsync(Aircraft aircraft)
        {
            return await entity.Where(x => x.Code == aircraft.Code).FirstOrDefaultAsync();
        }

        public int Insert(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Aircraft aircraft = new Aircraft
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    context.Add(aircraft);
                    context.SaveChanges();
                    transaction.Commit();
                    return aircraft.AircraftId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Aircraft", e);
                }
            }
        }

        public async Task<int> InsertAsync(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    Aircraft aircraft = new Aircraft
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    await context.AddAsync(aircraft);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return aircraft.AircraftId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Aircraft Async", e);
                }
            }
        }
    }
}
