using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Microsoft.EntityFrameworkCore.Storage;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class FlightRepository : Repository<Flight, int>, IFlightRepository
    {
        public FlightRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(Flight model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.FlightId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Flight", e);
                }
            }
        }

        public async Task<int> InsertAsync(Flight model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    await context.AddAsync(model);
                    await context.SaveChangesAsync();
                    transaction.Commit();
                    return model.FlightId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Flight", e);
                }
            }
        }

        public Flight Find(string origin, string destination, DateTime date, string currency)
        {
            return entity.Include(x => x.Currency)
                .Where(x => x.Currency.Code == currency && x.Destination == destination && x.Origin == origin && x.DepartureDate == date)
                .FirstOrDefault();
        }

        public async Task<Flight> FindAsync(string origin, string destination, DateTime date, string currency)
        {
            return await entity.Include(x => x.Currency)
                .Where(x => x.Currency.Code == currency && x.Destination == destination && x.Origin == origin && x.DepartureDate == date)
                .FirstOrDefaultAsync();
        }

        public Flight Find(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults)
        {
            return entity.Include(x => x.Currency)
                .Where(x => x.Origin == origin
                    && x.Destination == destination
                    && x.DepartureDate == departureDate
                    && x.ReturnDate == returnDate
                    && x.Currency.Code == currency
                    && x.Adults == adults)
                .FirstOrDefault();
        }

        public async Task<Flight> FindAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults)
        {
            return await entity.Include(x => x.Currency)
                .Where(x => x.Origin == origin 
                    && x.Destination == destination 
                    && x.DepartureDate == departureDate 
                    && x.ReturnDate == returnDate
                    && x.Currency.Code == currency
                    && x.Adults == adults)
                .FirstOrDefaultAsync();
        }

        public Tuple<int, Flight> GetFlights(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults)
        {
            return new Tuple<int, Flight>(1, entity.AsNoTracking()
                    .Include(x => x.Currency)
                    .Where(x => x.Origin == origin
                        && x.Destination == destination
                        && x.DepartureDate == departureDate
                        && x.ReturnDate == returnDate
                        && x.Currency.Code == currency
                        && x.Adults == adults)
                    .FirstOrDefault());
        }

        public async Task<Tuple<int, Flight>> GetFlightsAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults)
        {
            return new Tuple<int, Flight>(1, await entity.AsNoTracking()
                    .Include(x => x.Currency)
                    .Where(x => x.Origin == origin
                        && x.Destination == destination
                        && x.DepartureDate == departureDate
                        && x.ReturnDate == returnDate
                        && x.Currency.Code == currency
                        && x.Adults == adults)
                    .FirstOrDefaultAsync());
        }
    }
}
