using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Jasarsoft.AmadeusDev.Repo.Models;
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


        public Repo.Models.Flights.Flight Response(string origin, string destination, string date)
        {
            string uri = String.Format("https://test.api.amadeus.com/v1/shopping/flight-offers?origin=NYC&destination=MAD&departureDate=2019-08-01");

            string get = Server.Get(uri, Server.GetToken());

            #if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
            System.Diagnostics.Debug.WriteLine(get);
            #endif

            return JsonConvert.DeserializeObject<Repo.Models.Flights.Flight>(get);
        }

        public int Insert(Repo.Models.Flights.Flight model, string origin, string destionation, string date)
        {
            if (model == null) throw new ArgumentNullException();

            

            foreach (var item in model.Dictionaries.Currencies)
            {
                unitOfWork.Currencies.Insert(item);
            }

            foreach (var item in model.Dictionaries.Aircraft)
            {
                unitOfWork.Aircrafts.Insert(item);
            }

            foreach (var item in model.Dictionaries.Carriers)
            {
                unitOfWork.Carriers.Insert(item);
            }

            foreach (var item in model.Dictionaries.Locations)
            {
                unitOfWork.Locations.Insert(new KeyValuePair<string, string>(item.Key, item.Value.detailedName));
            }

            Currency currency = unitOfWork.Currencies.FindByCode(model.Meta.Currency);

            Flight flight = new Flight()
            {
                Currency = currency,
                CurrencyId = currency.CurrencyId,
                Origin = origin,
                Destination = destionation,
                DepartureDate = DateTime.Parse(date),
                Link = model.Meta.Links.Self,
            };

            var flightId = unitOfWork.Flights.Insert(flight);
            

            foreach (var item in model.Data)
            {
                FlightOffer flightOffer = new FlightOffer
                {
                    FlightId = flightId,
                    Id = item.Id,
                    Type = item.Type,
                };

                var flightOfferId = unitOfWork.FlightOffers.Insert(flightOffer);
                foreach (var offer in item.OfferItems)
                {
                    OfferItem offerItem = new OfferItem();
                    offerItem.FlightOfferId = flightOfferId;

                    Price price = new Price
                    {
                        Total = offer.Price.Total,
                        TotalTaxes = offer.Price.TotalTaxes,
                    };
                    offerItem.PriceId = unitOfWork.Prices.Insert(price);

                    if (offer.PricePerAdult != null)
                    {
                        Price adult = new Price
                        {
                            Total = offer.PricePerAdult.Total,
                            TotalTaxes = offer.PricePerAdult.TotalTaxes,
                        };
                        offerItem.PricePerAdultId = unitOfWork.Prices.Insert(adult);
                    }

                    if (offer.PricePerChild != null)
                    {
                        Price child = new Price
                        {
                            Total = offer.PricePerChild.Total,
                            TotalTaxes = offer.PricePerChild.TotalTaxes,
                        };
                        offerItem.PricePerChildId = unitOfWork.Prices.Insert(child);
                    }

                    if (offer.PricePerInfant != null)
                    {
                        Price infant = new Price
                        {
                            Total = offer.PricePerInfant.Total,
                            TotalTaxes = offer.PricePerInfant.TotalTaxes,
                        };
                        offerItem.PricePerInfantId = unitOfWork.Prices.Insert(infant);
                    }

                    if (offer.PricePerSenior != null)
                    {
                        Price senior = new Price
                        {
                            Total = offer.PricePerSenior.Total,
                            TotalTaxes = offer.PricePerSenior.TotalTaxes,
                        };
                        offerItem.PricePerSeniorId = unitOfWork.Prices.Insert(senior);
                    }

                    var offerItemId = unitOfWork.OfferItems.Insert(offerItem);

                    foreach (var ser in offer.Services)
                    {
                        Data.Flights.Service service = new Data.Flights.Service();
                        service.OfferItemId = offerItemId;

                        var serviceId = unitOfWork.Services.Insert(service);

                        if (ser.Segments != null)
                        {
                            foreach (var seg in ser.Segments)
                            {
                                Segment segment = new Segment();
                                segment.ServiceId = serviceId;

                                FlightSegment flightSegment = new FlightSegment();
                                flightSegment.AircraftId = unitOfWork.Aircrafts.FindByCode(seg.FlightSegment.Aircraft.Code).AircraftId;

                                FlightEndPoint arrival = new FlightEndPoint
                                {
                                    At = seg.FlightSegment.Arrival.At,
                                    LocationId = unitOfWork.Locations.FindByCode(seg.FlightSegment.Arrival.IataCode).LocationId,
                                    Terminal = seg.FlightSegment.Arrival.Terminal,
                                };
                                flightSegment.ArrivalId = unitOfWork.FlightEndPoints.Insert(arrival);
                                flightSegment.CarrierId = unitOfWork.Carriers.FindByCode(seg.FlightSegment.CarrierCode).CarrierId;

                                FlightEndPoint departure = new FlightEndPoint
                                {
                                    At = seg.FlightSegment.Departure.At,
                                    LocationId = unitOfWork.Locations.FindByCode(seg.FlightSegment.Departure.IataCode).LocationId,
                                    Terminal = seg.FlightSegment.Departure.Terminal,
                                };
                                flightSegment.DepartureId = unitOfWork.FlightEndPoints.Insert(departure);
                                flightSegment.Duration = seg.FlightSegment.Duration;
                                flightSegment.Number = seg.FlightSegment.Number;

                                Operation operation = new Operation
                                {
                                    CarrierId = unitOfWork.Carriers.FindByCode(seg.FlightSegment.Operating.CarrierCode).CarrierId,
                                    Number = seg.FlightSegment.Operating.Number,
                                };
                                flightSegment.OperationId = unitOfWork.Operations.Insert(operation);
                                segment.FlightSegmentId = unitOfWork.FlightSegments.Insert(flightSegment);

                                if (seg.FlightSegment.Stops != null)
                                {
                                    foreach (var stop in seg.FlightSegment.Stops)
                                    {
                                        FlightStop flightStop = new FlightStop
                                        {
                                            AircraftId = unitOfWork.Aircrafts.FindByCode(stop.NewAircraft.Code).AircraftId,
                                            ArrivalAt = stop.ArrivalAt,
                                            CarrierId = unitOfWork.Carriers.FindByCode(stop.IataCode).CarrierId,
                                            DepartureAt = stop.DepartureAt,
                                            Duration = stop.Duration,
                                            FlightSegmentId = segment.FlightSegmentId,
                                        };
                                        unitOfWork.FlightStops.Insert(flightStop);
                                    }
                                }

                                if (seg.PricingDetailPerAdult != null)
                                {
                                    PricingDetail adult = new PricingDetail
                                    {
                                        Availability = seg.PricingDetailPerAdult.Availability,
                                        FareBasis = seg.PricingDetailPerAdult.FareBasis,
                                        FareClass = seg.PricingDetailPerAdult.FareClass,
                                        TravelClass = seg.PricingDetailPerAdult.TravelClass,
                                    };
                                    segment.PricingDetailPerAdultId = unitOfWork.PricingDetails.Insert(adult);
                                }

                                if (seg.PricingDetailPerChild != null)
                                {
                                    PricingDetail child = new PricingDetail
                                    {
                                        Availability = seg.PricingDetailPerChild.Availability,
                                        FareBasis = seg.PricingDetailPerChild.FareBasis,
                                        FareClass = seg.PricingDetailPerChild.FareClass,
                                        TravelClass = seg.PricingDetailPerChild.TravelClass,
                                    };
                                    segment.PricingDetailPerChildId = unitOfWork.PricingDetails.Insert(child);
                                }

                                if (seg.PricingDetailPerInfant != null)
                                {
                                    PricingDetail infant = new PricingDetail
                                    {
                                        Availability = seg.PricingDetailPerInfant.Availability,
                                        FareBasis = seg.PricingDetailPerInfant.FareBasis,
                                        FareClass = seg.PricingDetailPerInfant.FareClass,
                                        TravelClass = seg.PricingDetailPerInfant.TravelClass,
                                    };
                                    segment.PricingDetailPerInfantId = unitOfWork.PricingDetails.Insert(infant);
                                }

                                if (seg.PricingDetailPerSenior != null)
                                {
                                    PricingDetail senior = new PricingDetail
                                    {
                                        Availability = seg.PricingDetailPerSenior.Availability,
                                        FareBasis = seg.PricingDetailPerSenior.FareBasis,
                                        FareClass = seg.PricingDetailPerSenior.FareClass,
                                        TravelClass = seg.PricingDetailPerSenior.TravelClass,
                                    };
                                    segment.PricingDetailPerSeniorId = unitOfWork.PricingDetails.Insert(senior);
                                }

                                unitOfWork.Segments.Insert(segment);
                            }
                        }
                       
                    }
                }

            }

            return flightId;
        }

        public int GetNumberOfFlights(string origin, string destination, string date)
        {
            var result = 0;
            var flight = unitOfWork.Flights.Find(origin, destination, DateTime.Parse(date), "EUR");
            if (flight == null)
            {
                return 0;
            }

            var flightOffers = unitOfWork.FlightOffers.GetByFlightId(flight.FlightId);
            foreach (var flightOffer in flightOffers)
            {
                result += unitOfWork.OfferItems.GetByFlightOfferId(flightOffer.FlightOfferId).Count();
            }

            return result;
        }

        public IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string origin, string destination, string date)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var flight = unitOfWork.Flights.Find(origin, destination, DateTime.Parse(date), "EUR");
            if (flight == null)
            {
                var model = Response(origin, destination, date);
                var flightId = Insert(model, origin, destination, date);
                flight = unitOfWork.Flights.Find(flightId);
            }

            var flightOffers = unitOfWork.FlightOffers.GetByFlightId(flight.FlightId);
            foreach (var flightOffer in flightOffers)
            {
                var dto = new FlightDTO();
                dto.Currency = "EUR";

                var offerItems = unitOfWork.OfferItems.GetByFlightOfferId(flightOffer.FlightOfferId);
                foreach (var offerItem in offerItems)
                {
                    dto.Price = Convert.ToDouble(offerItem.Price.Total, System.Globalization.CultureInfo.InvariantCulture).ToString() + " " + dto.Currency;

                    var services = unitOfWork.Services.GetByOfferItemId(offerItem.OfferItemId);
                    foreach (var service in services)
                    {

                        var segments = unitOfWork.Segments.GetByServiceId(service.ServiceId).ToList();
                        dto.Arrival = segments[segments.Count - 1].FlightSegment.Arrival.Location.Name;
                        dto.ArrivalTime = DateTime.Parse(segments[segments.Count - 1].FlightSegment.Arrival.At).ToString("U");
                        dto.DepartureTransfer = segments.Count;
                        dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                        dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                        dto.Passanger = Convert.ToInt32(segments[0].FlightSegment.Number);
                        foreach (var segment in segments)
                        {
                            if (dto.Passanger < Convert.ToInt32(segment.FlightSegment.Number))
                                dto.Passanger = Convert.ToInt32(segment.FlightSegment.Number);
                        }
                    }
                }

                flights.Add(dto);
            }


            return flights;  
        }
    }
}
