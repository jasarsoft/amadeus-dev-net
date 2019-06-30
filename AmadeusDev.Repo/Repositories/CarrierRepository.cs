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

                    if (!base.Contains(carrier))
                    {
                        context.Add(carrier);
                        context.SaveChanges();
                        transaction.Commit();
                        return carrier.CarrierId;
                    }

                    return 0;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Carrier", e);
                }
            }
        }
    }
}
