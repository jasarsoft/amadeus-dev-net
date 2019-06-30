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

                    var result = FindByCode(carrier);

                    if (result == null)
                    {
                        context.Add(carrier);
                        context.SaveChanges();
                        transaction.Commit();
                        return carrier.CarrierId;
                    }

                    return result.CarrierId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Carrier", e);
                }
            }
        }

        public Carrier FindByCode(string code)
        {
            return base.Where(x => x.Code == code).First();
        }

        public Carrier FindByCode(Carrier carrier)
        {
            return base.Where(x => x.Code == carrier.Code).First();
        }
    }
}
