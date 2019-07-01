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
    public class PricingDetailRepository : Repository<PricingDetail, int>, IPricingDetailRepository
    {
        public PricingDetailRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(PricingDetail model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.PricingDetailId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert PricingDetail", e);
                }
            }
        }
    }
}
