using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flight;
using Jasarsoft.AmadeusDev.Repo.DTO;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightRepository : IRepository<Flights, int>
    {
        void InsertFlights(Flights model);
        Task<int> InsertFlightsAsync(Flights model);
       
        IEnumerable<FlightDTO> GetFlights(int start, int take, OrderBy order, string column, string departure, string arrival, string date);
    }
}
