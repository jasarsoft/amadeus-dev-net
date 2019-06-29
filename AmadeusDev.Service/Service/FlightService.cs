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
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork unitOfWork;

        public FlightService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public Flights ResponseFromServer(string departure, string arrival)
        {
            string uri = String.Format("https://test.api.amadeus.com/v1/shopping/flight-offers?origin=NYC&destination=MAD&departureDate=2019-08-01");

            string get = Server.Get(uri, Server.GetToken());

#if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
            System.Diagnostics.Debug.WriteLine(get);
#endif
            return JsonConvert.DeserializeObject<Flights>(get);
        }

        public int GetNumberOfFlights()
        {
            return unitOfWork.FlightStops.Count();
        }


        public void InsertFlight(Flights model)
        {
            if (model == null) throw new ArgumentNullException();
            unitOfWork.FlightOffers.InsertFlights(model);
        }

        public async Task<int> InsertFlightsAsync(Flights model)
        {
            if (model == null) throw new ArgumentNullException();
            return await unitOfWork.FlightOffers.InsertFlightsAsync(model);
        }

        public IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string departure, string arrival, string date)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var flightOffers = unitOfWork.FlightOffers.SortAndGetRange(start, take, x => x.FlightOffersId, orderBy);

            foreach (var item in flightOffers)
            {
                var flightOffer = unitOfWork.FlightOffer.GetByFlightId(item.FlightOffersId);
                foreach (var fo in flightOffer)
                {
                    var offerItem = unitOfWork.OfferItems.GetByFlightOfferId(fo.FlightOfferId);
                    foreach (var oi in offerItem)
                    {
                        var service = unitOfWork.Services.GetByOfferItemId(oi.OfferItemId);
                        foreach (var s in service)
                        {
                            var segments = unitOfWork.Segments.GetByServiceId(s.ServiceId);
                            foreach (var seg in segments)
                            {
                                flights.Add(new FlightDTO
                                {
                                    //Arrival = 
                                });
                            }
                           
                        }
                    }
                }
            }


            return unitOfWork.FlightOffers.GetFlights(start, take, orderBy, column, departure, arrival, date);
        }
    }
}
