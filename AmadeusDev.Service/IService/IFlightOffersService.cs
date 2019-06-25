using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Service.IService
{
    public interface IFlightOffersService
    {
        FlightOffers ResponseFromServer(string departure, string arrival);

        int GetNumberOfFlights();
        void InsertFlight(FlightOffers model);

        IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string departureSearch, string arrivalSearch);
    }
}
