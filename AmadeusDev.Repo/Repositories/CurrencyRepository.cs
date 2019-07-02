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


        public Currency FindByCode(Currency currency)
        {
            return entity.Where(x => x.Code == currency.Code).FirstOrDefault();
        }

        public async Task<Currency> FindByCodeAsync(Currency currency)
        {
            return await entity.Where(x => x.Code == currency.Code).FirstOrDefaultAsync();
        }

        public Currency FindByCode(string code)
        {
            return entity.Where(x => x.Code == code).FirstOrDefault();
        }

        public async Task<Currency> FindByCodeAsync(string code)
        {
            return await entity.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

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

                    context.Add(currency);
                    context.SaveChanges();
                    transaction.Commit();
                    return currency.CurrencyId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Currency", e);
                }
            }
        }

        public async Task<int> InsertAsync(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    Currency currency = new Currency
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    await context.AddAsync(currency);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return currency.CurrencyId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Currency Async", e);
                }
            }
        }
    }
}
