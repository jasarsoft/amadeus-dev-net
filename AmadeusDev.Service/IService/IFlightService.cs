using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.Models;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Service.IService
{
    public interface IFlightService
    {
        int GetNumberOfFlights(string origin, string destination, string date);

        int Insert(Repo.Models.Flights.Flight model, string origin, string destionation, string date);

        Repo.Models.Flights.Flight Response(string origin, string destination, string date);

        IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string departure, string arrival, string date);
    }
}
