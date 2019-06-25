using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Jasarsoft.AmadeusDev.Service.IService;
using Newtonsoft.Json;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Service.Service
{
    public class FlightOffersService : IFlightOffersService
    {
        private readonly IUnitOfWork unitOfWork;

        public FlightOffersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public FlightOffers ResponseFromServer(string departure, string arrival)
        {
            string uri = String.Format("https://test.api.amadeus.com/v1/shopping/flight-offers?origin=NYC&destination=MAD&departureDate=2019-08-01");

            string get = Server.Get(uri, Server.GetToken());

#if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
            System.Diagnostics.Debug.WriteLine(get);
#endif
            return JsonConvert.DeserializeObject<FlightOffers>(get);
        }

        public int GetNumberOfFlights()
        {
            return unitOfWork.FlightStops.Count();
        }


        public void InsertFlight(FlightOffers model)
        {
            if (model == null) throw new ArgumentNullException();
            unitOfWork.FlightOffers.InsertFlights(model);
        }

        public async Task<int> InsertFlightsAsync(FlightOffers model)
        {
            if (model == null) throw new ArgumentNullException();
            return await unitOfWork.FlightOffers.InsertFlightsAsync(model);
        }

        public IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string departureSearch, string arrivalSearch)
        {
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            return unitOfWork.FlightOffers.GetFlights(start, take, orderBy, column, departureSearch, arrivalSearch);
        }
    }
}
