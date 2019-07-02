using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class LocationRepository : Repository<Location, int>, ILocationRepository
    {
        public LocationRepository(AmadeusDevContext context) : base(context) { }


        public Location FindByCode(string code)
        {
            return entity.Where(x => x.Code == code).FirstOrDefault();
        }

        public async Task<Location> FindByCodeAsync(string code)
        {
            return await entity.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public Location FindByCode(Location location)
        {
            return entity.Where(x => x.Code == location.Code).FirstOrDefault();
        }

        public async Task<Location> FindByCodeAsync(Location location)
        {
            return await entity.Where(x => x.Code == location.Code).FirstOrDefaultAsync();
        }

        public int Insert(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Location location = new Location
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    context.Add(location);
                    context.SaveChanges();
                    transaction.Commit();
                    return location.LocationId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Location", e);
                }
            }
        }

        public async Task<int> InsertAsync(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    Location location = new Location
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    await context.AddAsync(location);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return location.LocationId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Location Async", e);
                }
            }
        }
    }
}
