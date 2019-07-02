using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.DTO;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightRepository : IRepository<Flight, int>
    {
        //void Insert(Models.Flights.Flight model);
        int Insert(Flight model);
        Task<int> InsertFlightsAsync(Flight model);
        Flight Find(string origin, string destination, DateTime departureDate, string currency);
        Flight Find(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults);
        IEnumerable<FlightDTO> GetFlights(int start, int take, OrderBy order, string column, string departure, string arrival, string date);
    }
}
