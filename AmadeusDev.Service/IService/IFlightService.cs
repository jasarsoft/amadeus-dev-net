using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Service.IService
{
    public interface IFlightService
    {
        Flights ResponseFromServer(string departure, string arrival);

        int GetNumberOfFlights();
        void InsertFlight(Flights model);
        Task<int> InsertFlightsAsync(Flights model);

        IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string departure, string arrival, string date);
    }
}
