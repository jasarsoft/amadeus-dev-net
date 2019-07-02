using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.Models;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Service.IService
{
    public interface IFlightService
    {
        int GetNumberOfFlights(string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS);

        int Insert(Repo.Models.Flights.Flight model, string origin, string destionation, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS);

        Repo.Models.Flights.Flight Response(string origin, string destination, string departureDate, string returnDate = null,  string currency = Default.CURRENCY, int adults = Default.ADULTS);

        IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS);
    }
}
