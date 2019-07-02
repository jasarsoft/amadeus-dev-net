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
    public class FlightEndPointRepository : Repository<FlightEndPoint, int>, IFlightEndPointRepository
    {
        public FlightEndPointRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(FlightEndPoint model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.FlightEndPointId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightEndPoint", e);
                }
            }
        }

        public async Task<int> InsertAsync(FlightEndPoint model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.AddAsync(model);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return model.FlightEndPointId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert FlightEndPoint Async", e);
                }
            }
        }
    }
}
