using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.DTO;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightOffersRepository : IRepository<FlightOffers, int>
    {
        void InsertFlights(FlightOffers model);
        Task<int> InsertFlightsAsync(FlightOffers model);
       
        IEnumerable<FlightDTO> GetFlights(int start, int take, OrderBy order, string column, string departure, string arrival, string date);
    }
}
