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
        int Insert(Flight model);
        
        Flight Find(string origin, string destination, DateTime departureDate, string currency);
        Flight Find(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults);

        Tuple<int, Flight> GetFlights(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults);


        Task<int> InsertAsync(Flight model);

        Task<Flight> FindAsync(string origin, string destination, DateTime departureDate, string currency);
        Task<Flight> FindAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults);

        Task<Tuple<int, Flight>> GetFlightsAsync(string origin, string destination, DateTime departureDate, DateTime returnDate, string currency, int adults);
    }
}
