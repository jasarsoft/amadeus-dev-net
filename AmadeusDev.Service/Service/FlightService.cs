﻿using System;
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


        public Repo.Models.Flights.Flight Response(string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            string uri = "https://test.api.amadeus.com/v1/shopping/flight-offers?";
            uri += String.Format("origin={0}&destination={1}&departureDate={2}", origin, destination, departureDate);
            if (!String.IsNullOrEmpty(returnDate))
                uri += String.Format("&returnDate={0}", returnDate);
            if (!String.IsNullOrEmpty(currency))
                uri += String.Format("&currency={0}", currency);
            if (adults != 1)
                uri += String.Format("&adults={0}", adults);

            string get = Server.Get(uri, Server.GetToken());

 #if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
            System.Diagnostics.Debug.WriteLine(get);
#endif

            return JsonConvert.DeserializeObject<Repo.Models.Flights.Flight>(get);
        }

        public async Task<Repo.Models.Flights.Flight> ResponseAsync(string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            string uri = "https://test.api.amadeus.com/v1/shopping/flight-offers?";
            uri += String.Format("origin={0}&destination={1}&departureDate={2}", origin, destination, departureDate);
            if (!String.IsNullOrEmpty(returnDate))
                uri += String.Format("&returnDate={0}", returnDate);
            if (!String.IsNullOrEmpty(currency))
                uri += String.Format("&currency={0}", currency);
            if (adults != 1)
                uri += String.Format("&adults={0}", adults);

            string get = await Server.GetAsync(uri, Server.GetToken());

            return JsonConvert.DeserializeObject<Repo.Models.Flights.Flight>(get);
        }


        public int Insert(Repo.Models.Flights.Flight model, string origin, string destionation, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            if (model == null || String.IsNullOrEmpty(origin) || String.IsNullOrEmpty(destionation) || String.IsNullOrEmpty(departureDate))
                throw new ArgumentNullException();

            if (model.Data == null || model.Dictionaries == null || model.Meta == null)
                throw new NullReferenceException();

            if (model.Dictionaries.Currencies != null)
            {
                foreach (var item in model.Dictionaries.Currencies)
                {
                    if (unitOfWork.Currencies.FindByCode(item.Key) == null)
                    {
                        unitOfWork.Currencies.Insert(item);
                    }
                }
            }

            if (model.Dictionaries.Aircraft != null)
            {
                foreach (var item in model.Dictionaries.Aircraft)
                {
                    if (unitOfWork.Aircrafts.FindByCode(item.Key) == null)
                    {
                        unitOfWork.Aircrafts.Insert(item);
                    }
                }
            }

            if (model.Dictionaries.Carriers != null)
            {
                foreach (var item in model.Dictionaries.Carriers)
                {
                    if (unitOfWork.Carriers.FindByCode(item.Key) == null)
                    {
                        unitOfWork.Carriers.Insert(item);
                    }
                }
            }

            if (model.Dictionaries.Locations != null)
            {
                foreach (var item in model.Dictionaries.Locations)
                {
                    if (unitOfWork.Locations.FindByCode(item.Key) == null)
                    {
                        unitOfWork.Locations.Insert(new KeyValuePair<string, string>(item.Key, item.Value.detailedName));
                    }
                }
            }


            Flight flight = new Flight()
            {
                Adults = adults,
                CurrencyId = unitOfWork.Currencies.FindByCode(model.Meta.Currency).CurrencyId,
                Origin = origin,
                Destination = destionation,
                DepartureDate = DateTime.Parse(departureDate),
                ReturnDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString()),
                Link = model.Meta.Links.Self,
            };

            flight.FlightId = unitOfWork.Flights.Insert(flight);

            try
            {
                foreach (var item in model.Data)
                {
                    FlightOffer flightOffer = new FlightOffer
                    {
                        Id = item.Id,
                        Type = item.Type,
                        FlightId = flight.FlightId,
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

                                    var segmentId = unitOfWork.Segments.Insert(segment);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return flight.FlightId;
        }

        public async Task<int> InsertAsync(Repo.Models.Flights.Flight model, string origin, string destionation, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            if (model == null || String.IsNullOrEmpty(origin) || String.IsNullOrEmpty(destionation) || String.IsNullOrEmpty(departureDate))
                throw new ArgumentNullException();

            if (model.Data == null || model.Dictionaries == null || model.Meta == null)
                throw new NullReferenceException();

            if (model.Dictionaries.Currencies != null)
            {
                foreach (var item in model.Dictionaries.Currencies)
                {
                    if (unitOfWork.Currencies.FindByCode(item.Key) == null)
                    {
                        await unitOfWork.Currencies.InsertAsync(item);
                    }
                }
            }

            if (model.Dictionaries.Aircraft != null)
            {
                foreach (var item in model.Dictionaries.Aircraft)
                {
                    if (unitOfWork.Aircrafts.FindByCode(item.Key) == null)
                    {
                        await unitOfWork.Aircrafts.InsertAsync(item);
                    }
                }
            }

            if (model.Dictionaries.Carriers != null)
            {
                foreach (var item in model.Dictionaries.Carriers)
                {
                    if (unitOfWork.Carriers.FindByCode(item.Key) == null)
                    {
                        await unitOfWork.Carriers.InsertAsync(item);
                    }
                }
            }

            if (model.Dictionaries.Locations != null)
            {
                foreach (var item in model.Dictionaries.Locations)
                {
                    if (unitOfWork.Locations.FindByCode(item.Key) == null)
                    {
                        await unitOfWork.Locations.InsertAsync(new KeyValuePair<string, string>(item.Key, item.Value.detailedName));
                    }
                }
            }


            Flight flight = new Flight()
            {
                Adults = adults,
                CurrencyId = unitOfWork.Currencies.FindByCode(model.Meta.Currency).CurrencyId,
                Origin = origin,
                Destination = destionation,
                DepartureDate = DateTime.Parse(departureDate),
                ReturnDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString()),
                Link = model.Meta.Links.Self,
            };

            flight.FlightId = await unitOfWork.Flights.InsertAsync(flight);

            try
            {
                foreach (var item in model.Data)
                {
                    FlightOffer flightOffer = new FlightOffer
                    {
                        Id = item.Id,
                        Type = item.Type,
                        FlightId = flight.FlightId,
                    };

                    var flightOfferId = await unitOfWork.FlightOffers.InsertAsync(flightOffer);
                    foreach (var offer in item.OfferItems)
                    {
                        OfferItem offerItem = new OfferItem();
                        offerItem.FlightOfferId = flightOfferId;

                        Price price = new Price
                        {
                            Total = offer.Price.Total,
                            TotalTaxes = offer.Price.TotalTaxes,
                        };
                        offerItem.PriceId = await unitOfWork.Prices.InsertAsync(price);

                        if (offer.PricePerAdult != null)
                        {
                            Price adult = new Price
                            {
                                Total = offer.PricePerAdult.Total,
                                TotalTaxes = offer.PricePerAdult.TotalTaxes,
                            };
                            offerItem.PricePerAdultId = await unitOfWork.Prices.InsertAsync(adult);
                        }

                        if (offer.PricePerChild != null)
                        {
                            Price child = new Price
                            {
                                Total = offer.PricePerChild.Total,
                                TotalTaxes = offer.PricePerChild.TotalTaxes,
                            };
                            offerItem.PricePerChildId = await unitOfWork.Prices.InsertAsync(child);
                        }

                        if (offer.PricePerInfant != null)
                        {
                            Price infant = new Price
                            {
                                Total = offer.PricePerInfant.Total,
                                TotalTaxes = offer.PricePerInfant.TotalTaxes,
                            };
                            offerItem.PricePerInfantId = await unitOfWork.Prices.InsertAsync(infant);
                        }

                        if (offer.PricePerSenior != null)
                        {
                            Price senior = new Price
                            {
                                Total = offer.PricePerSenior.Total,
                                TotalTaxes = offer.PricePerSenior.TotalTaxes,
                            };
                            offerItem.PricePerSeniorId = await unitOfWork.Prices.InsertAsync(senior);
                        }

                        var offerItemId = await unitOfWork.OfferItems.InsertAsync(offerItem);
                        foreach (var ser in offer.Services)
                        {
                            Data.Flights.Service service = new Data.Flights.Service();
                            service.OfferItemId = offerItemId;

                            var serviceId = await unitOfWork.Services.InsertAsync(service);
                            if (ser.Segments != null)
                            {
                                foreach (var seg in ser.Segments)
                                {
                                    Segment segment = new Segment();
                                    segment.ServiceId = serviceId;

                                    FlightSegment flightSegment = new FlightSegment();
                                    flightSegment.AircraftId = (await unitOfWork.Aircrafts.FindByCodeAsync(seg.FlightSegment.Aircraft.Code)).AircraftId;

                                    FlightEndPoint arrival = new FlightEndPoint
                                    {
                                        At = seg.FlightSegment.Arrival.At,
                                        LocationId = (await unitOfWork.Locations.FindByCodeAsync(seg.FlightSegment.Arrival.IataCode)).LocationId,
                                        Terminal = seg.FlightSegment.Arrival.Terminal,
                                    };
                                    flightSegment.ArrivalId = await unitOfWork.FlightEndPoints.InsertAsync(arrival);
                                    flightSegment.CarrierId = (await unitOfWork.Carriers.FindByCodeAsync(seg.FlightSegment.CarrierCode)).CarrierId;

                                    FlightEndPoint departure = new FlightEndPoint
                                    {
                                        At = seg.FlightSegment.Departure.At,
                                        LocationId = (await unitOfWork.Locations.FindByCodeAsync(seg.FlightSegment.Departure.IataCode)).LocationId,
                                        Terminal = seg.FlightSegment.Departure.Terminal,
                                    };
                                    flightSegment.DepartureId = await unitOfWork.FlightEndPoints.InsertAsync(departure);
                                    flightSegment.Duration = seg.FlightSegment.Duration;
                                    flightSegment.Number = seg.FlightSegment.Number;

                                    Operation operation = new Operation
                                    {
                                        CarrierId = (await unitOfWork.Carriers.FindByCodeAsync(seg.FlightSegment.Operating.CarrierCode)).CarrierId,
                                        Number = seg.FlightSegment.Operating.Number,
                                    };
                                    flightSegment.OperationId = await unitOfWork.Operations.InsertAsync(operation);

                                    segment.FlightSegmentId = await unitOfWork.FlightSegments.InsertAsync(flightSegment);

                                    if (seg.FlightSegment.Stops != null)
                                    {
                                        foreach (var stop in seg.FlightSegment.Stops)
                                        {
                                            FlightStop flightStop = new FlightStop
                                            {
                                                AircraftId = (await unitOfWork.Aircrafts.FindByCodeAsync(stop.NewAircraft.Code)).AircraftId,
                                                ArrivalAt = stop.ArrivalAt,
                                                CarrierId = (await unitOfWork.Carriers.FindByCodeAsync(stop.IataCode)).CarrierId,
                                                DepartureAt = stop.DepartureAt,
                                                Duration = stop.Duration,
                                                FlightSegmentId = segment.FlightSegmentId,
                                            };
                                            await unitOfWork.FlightStops.InsertAsync(flightStop);
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
                                        segment.PricingDetailPerAdultId = await unitOfWork.PricingDetails.InsertAsync(adult);
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
                                        segment.PricingDetailPerChildId = await unitOfWork.PricingDetails.InsertAsync(child);
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
                                        segment.PricingDetailPerInfantId = await unitOfWork.PricingDetails.InsertAsync(infant);
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
                                        segment.PricingDetailPerSeniorId = await unitOfWork.PricingDetails.InsertAsync(senior);
                                    }

                                    var segmentId = await unitOfWork.Segments.InsertAsync(segment);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return flight.FlightId;
        }

        public int GetNumberOfFlights(string origin, string destination, string departureDate,
            string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            var result = 0;
            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());

            var flight = unitOfWork.Flights.Find(origin, destination, depDate, retDate, currency, adults);
            if (flight != null)
            {
                var flightOffers = unitOfWork.FlightOffers.GetByFlightId(flight.FlightId);
                foreach (var flightOffer in flightOffers)
                {
                    result += unitOfWork.OfferItems.GetByFlightOfferId(flightOffer.FlightOfferId).Count();
                }
            }

            return result;
        }

        public async Task<int> GetNumberOfFlightsAsync(string origin, string destination, string departureDate, 
            string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            var result = 0;
            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());

            var flight = await unitOfWork.Flights.FindAsync(origin, destination, depDate, retDate, currency, adults);
            if (flight != null)
            {
                var flightOffers = await unitOfWork.FlightOffers.GetByFlightIdAsync(flight.FlightId);
                foreach (var flightOffer in flightOffers)
                {
                    result += (await unitOfWork.OfferItems.GetByFlightOfferIdAsync(flightOffer.FlightOfferId)).Count();
                }
            }

            return result;
        }

        public IEnumerable<FlightDTO> GetFlights(int start, int take, string order, string column, string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());
            
            var flight = unitOfWork.Flights.Find(origin, destination, depDate, retDate = depDate < retDate ? retDate : DateTime.MinValue, currency, adults);
            if (flight == null)
            {
                var model = Response(origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                if (model.Warnings != null) return null;
                var flightId = Insert(model, origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                flight = unitOfWork.Flights.Find(flightId);
            }

            var flightOffers = unitOfWork.FlightOffers.SortAndGetRange(flight.FlightId, start, take, x => x.FlightId, orderBy);
            foreach (var flightOffer in flightOffers)
            {
                var dto = new FlightDTO();
                dto.Adults = flight.Adults;
                dto.Currency = flight.Currency.Code;

                var offerItems = unitOfWork.OfferItems.GetByFlightOfferId(flightOffer.FlightOfferId);
                foreach (var offerItem in offerItems)
                {
                    dto.Price = Convert.ToDouble(offerItem.Price.Total, System.Globalization.CultureInfo.InvariantCulture).ToString() + " " + dto.Currency;

                    var services = unitOfWork.Services.GetByOfferItemId(offerItem.OfferItemId).ToList();
                    if (services.Count > 1) //kad imamo unesen i return date
                    {
                        for (int i = 0; i < services.Count; i++)
                        {
                            var segments = unitOfWork.Segments.GetByServiceId(services[i].ServiceId).ToList();
                            if (i == 0)
                            {
                                dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                                dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.DepartureTransfer = segments.Count - 1;
                            }

                            if (i == 1)
                            {
                                dto.Arrival = segments[0].FlightSegment.Departure.Location.Name;
                                dto.ArrivalTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.ArrivalTransfer = segments.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var service in services)
                        {
                            var segments = unitOfWork.Segments.GetByServiceId(service.ServiceId).ToList();

                            dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                            dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                            dto.DepartureTransfer = segments.Count - 1;

                            dto.Arrival = segments[segments.Count - 1].FlightSegment.Arrival.Location.Name;
                            dto.ArrivalTime = DateTime.Parse(segments[segments.Count - 1].FlightSegment.Arrival.At).ToString("U");
                            dto.ArrivalTransfer = -1; //obzirom da nema povratka ovaj podatak ce se koristit na frontendu 
                        }
                    }
                }

                flights.Add(dto);
            }

            return flights;  
        }

        public Tuple<int, IEnumerable<FlightDTO>> GetFlightsTuple(int start, int take, string order, string column, string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());

            var flight = unitOfWork.Flights.Find(origin, destination, depDate, retDate = depDate < retDate ? retDate : DateTime.MinValue, currency, adults);
            if (flight == null)
            {
                var model = Response(origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                if (model.Warnings != null) return null;
                var flightId = Insert(model, origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                flight = unitOfWork.Flights.Find(flightId);
            }

            var flightOffers = unitOfWork.FlightOffers.SortAndGetRange(flight.FlightId, start, take, x => x.FlightId, orderBy);
            foreach (var flightOffer in flightOffers)
            {
                var dto = new FlightDTO();
                dto.Adults = flight.Adults;
                dto.Currency = flight.Currency.Code;

                var offerItems = unitOfWork.OfferItems.GetByFlightOfferId(flightOffer.FlightOfferId);
                foreach (var offerItem in offerItems)
                {
                    dto.Price = Convert.ToDouble(offerItem.Price.Total, System.Globalization.CultureInfo.InvariantCulture).ToString() + " " + dto.Currency;

                    var services = unitOfWork.Services.GetByOfferItemId(offerItem.OfferItemId).ToList();
                    if (services.Count > 1) //kad imamo unesen i return date
                    {
                        for (int i = 0; i < services.Count; i++)
                        {
                            var segments = unitOfWork.Segments.GetByServiceId(services[i].ServiceId).ToList();
                            if (i == 0)
                            {
                                dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                                dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.DepartureTransfer = segments.Count - 1;
                            }

                            if (i == 1)
                            {
                                dto.Arrival = segments[0].FlightSegment.Departure.Location.Name;
                                dto.ArrivalTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.ArrivalTransfer = segments.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var service in services)
                        {
                            var segments = unitOfWork.Segments.GetByServiceId(service.ServiceId).ToList();

                            dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                            dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                            dto.DepartureTransfer = segments.Count - 1;

                            dto.Arrival = segments[segments.Count - 1].FlightSegment.Arrival.Location.Name;
                            dto.ArrivalTime = DateTime.Parse(segments[segments.Count - 1].FlightSegment.Arrival.At).ToString("U");
                            dto.ArrivalTransfer = -1; //obzirom da nema povratka ovaj podatak ce se koristit na frontendu 
                        }
                    }
                }

                flights.Add(dto);
            }

            return new Tuple<int, IEnumerable<FlightDTO>>(unitOfWork.FlightOffers.Count(flight.FlightId), flights);
        }

        public async Task<Tuple<int, IEnumerable<FlightDTO>>> GetFlightsTupleAsync(int start, int take, string order, string column, string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());

            var flight = await unitOfWork.Flights.FindAsync(origin, destination, depDate, retDate = depDate < retDate ? retDate : DateTime.MinValue, currency, adults);
            if (flight == null)
            {
                var model = await ResponseAsync(origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                if (model.Warnings != null) return null;
                var flightId = await InsertAsync(model, origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                flight = await unitOfWork.Flights.FindAsync(flightId);
            }

            var flightOffers = await unitOfWork.FlightOffers.SortAndGetRangeAsync(flight.FlightId, start, take, x => x.FlightId, orderBy);
            foreach (var flightOffer in flightOffers)
            {
                var dto = new FlightDTO();
                dto.Adults = flight.Adults;
                dto.Currency = flight.Currency.Code;

                var offerItems = await unitOfWork.OfferItems.GetByFlightOfferIdAsync(flightOffer.FlightOfferId);
                foreach (var offerItem in offerItems)
                {
                    dto.Price = Convert.ToDouble(offerItem.Price.Total, System.Globalization.CultureInfo.InvariantCulture).ToString() + " " + dto.Currency;

                    var services = (await unitOfWork.Services.GetByOfferItemIdAsync(offerItem.OfferItemId)).ToList();
                    if (services.Count > 1) //kad imamo unesen i return date
                    {
                        for (int i = 0; i < services.Count; i++)
                        {
                            var segments = (await unitOfWork.Segments.GetByServiceIdAsync(services[i].ServiceId)).ToList();
                            if (i == 0)
                            {
                                dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                                dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.DepartureTransfer = segments.Count - 1;
                            }

                            if (i == 1)
                            {
                                dto.Arrival = segments[0].FlightSegment.Departure.Location.Name;
                                dto.ArrivalTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.ArrivalTransfer = segments.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var service in services)
                        {
                            var segments = (await unitOfWork.Segments.GetByServiceIdAsync(service.ServiceId)).ToList();

                            dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                            dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                            dto.DepartureTransfer = segments.Count - 1;

                            dto.Arrival = segments[segments.Count - 1].FlightSegment.Arrival.Location.Name;
                            dto.ArrivalTime = DateTime.Parse(segments[segments.Count - 1].FlightSegment.Arrival.At).ToString("U");
                            dto.ArrivalTransfer = -1; //obzirom da nema povratka ovaj podatak ce se koristit na frontendu 
                        }
                    }
                }

                flights.Add(dto);
            }

            return new Tuple<int, IEnumerable<FlightDTO>>(await unitOfWork.FlightOffers.CountAsync(flight.FlightId), flights);
        }

        public async Task<IEnumerable<FlightDTO>> GetFlightsAsync(int start, int take, string order, string column, string origin, string destination, string departureDate, string returnDate = null, string currency = Default.CURRENCY, int adults = Default.ADULTS)
        {
            List<FlightDTO> flights = new List<FlightDTO>();
            OrderBy orderBy = (OrderBy)Enum.Parse(typeof(OrderBy), order.ToUpper());

            var depDate = DateTime.Parse(departureDate);
            var retDate = DateTime.Parse(returnDate ?? DateTime.MinValue.ToString());

            var flight = await unitOfWork.Flights.FindAsync(origin, destination, depDate, retDate = depDate < retDate ? retDate : DateTime.MinValue, currency, adults);
            if (flight == null)
            {
                var model = await ResponseAsync(origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                if (model.Warnings != null) return null;
                var flightId = await InsertAsync(model, origin, destination, departureDate, returnDate = depDate < retDate ? returnDate : null, currency, adults);
                flight = await unitOfWork.Flights.FindAsync(flightId);
            }

            var flightOffers = await unitOfWork.FlightOffers.SortAndGetRangeAsync(flight.FlightId, start, take, x => x.FlightId, orderBy);
            foreach (var flightOffer in flightOffers)
            {
                var dto = new FlightDTO();
                dto.Adults = flight.Adults;
                dto.Currency = flight.Currency.Code;

                var offerItems = await unitOfWork.OfferItems.GetByFlightOfferIdAsync(flightOffer.FlightOfferId);
                foreach (var offerItem in offerItems)
                {
                    dto.Price = Convert.ToDouble(offerItem.Price.Total, System.Globalization.CultureInfo.InvariantCulture).ToString() + " " + dto.Currency;

                    var services = (await unitOfWork.Services.GetByOfferItemIdAsync(offerItem.OfferItemId)).ToList();
                    if (services.Count > 1) //kad imamo unesen i return date
                    {
                        for (int i = 0; i < services.Count; i++)
                        {
                            var segments = (await unitOfWork.Segments.GetByServiceIdAsync(services[i].ServiceId)).ToList();
                            if (i == 0)
                            {
                                dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                                dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.DepartureTransfer = segments.Count - 1;
                            }

                            if (i == 1)
                            {
                                dto.Arrival = segments[0].FlightSegment.Departure.Location.Name;
                                dto.ArrivalTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                                dto.ArrivalTransfer = segments.Count - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (var service in services)
                        {
                            var segments = (await unitOfWork.Segments.GetByServiceIdAsync(service.ServiceId)).ToList();

                            dto.Departure = segments[0].FlightSegment.Departure.Location.Name;
                            dto.DepartureTime = DateTime.Parse(segments[0].FlightSegment.Departure.At).ToString("U");
                            dto.DepartureTransfer = segments.Count - 1;

                            dto.Arrival = segments[segments.Count - 1].FlightSegment.Arrival.Location.Name;
                            dto.ArrivalTime = DateTime.Parse(segments[segments.Count - 1].FlightSegment.Arrival.At).ToString("U");
                            dto.ArrivalTransfer = -1; //obzirom da nema povratka ovaj podatak ce se koristit na frontendu 
                        }
                    }
                }

                flights.Add(dto);
            }

            return flights;
        }
    }
}
