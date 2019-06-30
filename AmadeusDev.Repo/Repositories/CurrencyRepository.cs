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
    public class CurrencyRepository : Repository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Currency currency = new Currency
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    var result = FindByCode(currency);

                    if (result == null)
                    {
                        context.Add(currency);
                        context.SaveChanges();
                        transaction.Commit();
                        return currency.CurrencyId;
                    }

                    return result.CurrencyId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Currency", e);
                }
            }
        }

        public Currency FindByCode(Currency currency)
        {
            return base.Where(x => x.Code == currency.Code).FirstOrDefault();
        }

        public Currency FindByCode(string code)
        {
            return base.Where(x => x.Code == code).FirstOrDefault();
        }
    }
}
