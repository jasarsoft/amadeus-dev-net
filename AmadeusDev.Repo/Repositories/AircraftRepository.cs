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

        public Aircraft FindByCode(string code)
        {
            return base.Where(x => x.Code == code).FirstOrDefault();
        }

        public Aircraft FindByCode(Aircraft aircraft)
        {
            return base.Where(x => x.Code == aircraft.Code).FirstOrDefault();
        }
    }
}
