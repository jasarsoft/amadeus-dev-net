using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.DTO;
using Microsoft.EntityFrameworkCore.Storage;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class FlightOffersRepository : Repository<FlightOffers, int>, IFlightOffersRepository
    {
        public FlightOffersRepository(AmadeusDevContext context) : base(context) { }


        public IEnumerable<FlightDTO> GetFlights(int start, int take, OrderBy order, string column, string departureSearch, string arrivalSearch)
        {
            var query = context.FlightOffers
                .Include(x => x.Data)

                .Include(x => x.Dictionaries)
                    .ThenInclude(y => y.Aircraft)

                .Include(x => x.Meta)
                .Include(x => x.Data)
                .Skip(start).Take(take);

            //if (!String.IsNullOrEmpty(departureSearch))
            //    query = query.Where()

            return query.Select(x => new FlightDTO
            {
                Departure = x.DictionariesId.ToString(),
            });
        }

        public void InsertFlights(FlightOffers model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    FlightOffers flightOffers = new FlightOffers();
                    
                    Meta meta = new Meta();
                    if (model.Meta != null)
                    {
                        meta.Currency = model.Meta.Currency;

                        Links links = new Links();
                        if (model.Meta.Links != null)
                        {
                            links.Self = model.Meta.Links.Self;

                            context.Links.Add(links);
                            meta.LinksId = links.LinkId;
                        }

                        Defaults defaults = new Defaults();
                        if (model.Meta.Defaults != null)
                        {
                            defaults.Adults = model.Meta.Defaults.Adults;
                            defaults.NonStop = model.Meta.Defaults.NonStop;

                            context.Defaults.Add(defaults);
                            meta.DefaultsId = defaults.DefaultId;
                        }

                        context.Metas.Add(meta);
                        flightOffers.MetaId = meta.MetaId;
                    }

                    Dictionaries dictionaries = new Dictionaries();
                    if (model.Dictionaries != null)
                    {
                        DictionaryEntry aircraft = new DictionaryEntry();
                        if (model.Dictionaries.Aircraft != null)
                        {
                            aircraft.Code = model.Dictionaries.Aircraft.Code;

                            context.DictionaryEntries.Add(aircraft);
                            dictionaries.AircraftId = aircraft.DictionaryEntryId;
                        }

                        DictionaryEntry carriers = new DictionaryEntry();
                        if (model.Dictionaries.Carriers != null)
                        {
                            carriers.Code = model.Dictionaries.Carriers.Code;

                            context.DictionaryEntries.Add(carriers);
                            dictionaries.CarriersId = carriers.DictionaryEntryId;
                        }

                        DictionaryEntry currencies = new DictionaryEntry();
                        if (model.Dictionaries.Currencies != null)
                        {
                            currencies.Code = model.Dictionaries.Currencies.Code;

                            context.DictionaryEntries.Add(currencies);
                            dictionaries.CurrenciesId = currencies.DictionaryEntryId;
                        }

                        LocationEntry locations = new LocationEntry();
                        if (model.Dictionaries.Locations != null)
                        {
                            locations.Key = model.Dictionaries.Locations.Key;

                            context.LocationEntries.Add(locations);
                            dictionaries.LocationsId = locations.LocationEntryId;
                        }

                        context.Dictionaries.Add(dictionaries);
                        flightOffers.DictionariesId = dictionaries.DictionaryId;
                    }

                    context.FlightOffers.Add(flightOffers);

                    if (model.Data != null)
                    {
                        foreach (var item in model.Data)
                        {
                            FlightOffer data = new FlightOffer();
                            data.FlightOffersId = flightOffers.FlightOffersId;
                            data.Id = item.Id;
                            data.Type = item.Type;
                            context.FlightOffer.Add(data);

                            
                            if (item.OfferItems != null)
                            {
                                foreach (var offer in item.OfferItems)
                                {
                                    OfferItem offerItem = new OfferItem();
                                    offerItem.FlightOfferId = data.FlightOfferId;

                                    Price price = new Price();
                                    if (offer.Price != null)
                                    {
                                        price.Total = offer.Price.Total;
                                        price.TotalTaxes = offer.Price.TotalTaxes;

                                        context.Prices.Add(price);
                                        offerItem.PriceId = price.PriceId;
                                    }

                                    Price pricePerAdult = new Price();
                                    if (offer.PricePerAdult != null)
                                    {
                                        pricePerAdult.Total = offer.PricePerAdult.Total;
                                        pricePerAdult.TotalTaxes = offer.PricePerAdult.TotalTaxes;

                                        context.Prices.Add(pricePerAdult);
                                        offerItem.PricePerAdultId = pricePerAdult.PriceId;
                                    }

                                    Price pricePerInfant = new Price();
                                    if (offer.PricePerInfant != null)
                                    {
                                        pricePerInfant.Total = offer.PricePerInfant.Total;
                                        pricePerInfant.TotalTaxes = offer.PricePerInfant.TotalTaxes;

                                        context.Prices.Add(pricePerInfant);
                                        offerItem.PricePerInfantId = pricePerInfant.PriceId;
                                    }

                                    Price pricePerChild = new Price();
                                    if (offer.PricePerChild != null)
                                    {
                                        pricePerChild.Total = offer.PricePerChild.Total;
                                        pricePerChild.TotalTaxes = offer.PricePerChild.TotalTaxes;

                                        context.Prices.Add(pricePerChild);
                                        offerItem.PricePerChildId = pricePerChild.PriceId;
                                    }

                                    Price pricePerSenior = new Price();
                                    if (offer.PricePerSenior != null)
                                    {
                                        pricePerSenior.Total = offer.PricePerSenior.Total;
                                        pricePerSenior.TotalTaxes = offer.PricePerSenior.TotalTaxes;

                                        context.Prices.Add(pricePerSenior);
                                        offerItem.PricePerSeniorId = pricePerSenior.PriceId;
                                    }

                                    context.OfferItems.Add(offerItem);

                                    if (offer.Services != null)
                                    {                                        
                                        foreach (var s in offer.Services)
                                        {
                                            Service service = new Service();
                                            service.OfferItemId = offerItem.OfferItemId;
                                            context.Services.Add(service);

                                            if (s.Segments != null)
                                            {
                                                foreach (var seg in s.Segments)
                                                {
                                                    Segment segment = new Segment();
                                                    segment.ServiceId = service.ServiceId;

                                                    FlightSegment flightSegment = new FlightSegment();
                                                    if (seg.FlightSegment != null)
                                                    {
                                                        FlightEndPoint departure = new FlightEndPoint();
                                                        if (seg.FlightSegment.Departure != null)
                                                        {
                                                            departure.At = seg.FlightSegment.Departure.At;
                                                            departure.IataCode = seg.FlightSegment.Departure.IataCode;
                                                            departure.Terminal = seg.FlightSegment.Departure.Terminal;

                                                            context.FlightEndPoints.Add(departure);
                                                            flightSegment.DepartureId = departure.FlightEndPointId;
                                                        }

                                                        FlightEndPoint arrival = new FlightEndPoint();
                                                        if (seg.FlightSegment.Arrival != null)
                                                        {
                                                            arrival.At = seg.FlightSegment.Arrival.At;
                                                            arrival.IataCode = seg.FlightSegment.Arrival.IataCode;
                                                            arrival.Terminal = seg.FlightSegment.Arrival.Terminal;

                                                            context.FlightEndPoints.Add(arrival);
                                                            flightSegment.ArrivalId = arrival.FlightEndPointId;
                                                        }

                                                        AircraftEquipment aircraft = new AircraftEquipment();
                                                        if (seg.FlightSegment.Aircraft != null)
                                                        {
                                                            aircraft.Code = seg.FlightSegment.Aircraft.Code;

                                                            context.AircraftEquipments.Add(aircraft);
                                                            flightSegment.AircraftId = aircraft.AircraftEquipmentId;
                                                        }

                                                        OperatingFlight operating = new OperatingFlight();
                                                        if (seg.FlightSegment.Operating != null)
                                                        {
                                                            operating.CarrierCode = seg.FlightSegment.Operating.CarrierCode;
                                                            operating.Number = seg.FlightSegment.Operating.Number;

                                                            context.OperatingFlights.Add(operating);
                                                            flightSegment.OperatingId = operating.OperatingFlightId;
                                                        }

                                                        flightSegment.Duration = seg.FlightSegment.Duration;
                                                        flightSegment.CarrierCode = seg.FlightSegment.CarrierCode;
                                                        flightSegment.Number = seg.FlightSegment.Number;

                                                        context.FlightSegments.Add(flightSegment);
                                                        segment.FlightSegmentId = flightSegment.FlightSegmentId;
                                                        
                                                        if (seg.FlightSegment.Stops != null)
                                                        {
                                                            foreach (var stopItem in seg.FlightSegment.Stops)
                                                            {
                                                                FlightStop stop = new FlightStop();                                                                
                                                                stop.ArrivalAt = stopItem.ArrivalAt;
                                                                stop.DepartureAt = stopItem.DepartureAt;
                                                                stop.Duration = stopItem.Duration;
                                                                stop.IataCode = stopItem.IataCode;
                                                                
                                                                AircraftEquipment newAircraft = new AircraftEquipment();
                                                                if (stopItem.NewAircraft != null)
                                                                {
                                                                    newAircraft.Code = stopItem.NewAircraft.Code;

                                                                    context.AircraftEquipments.Add(newAircraft);
                                                                    stop.NewAircraftId = newAircraft.AircraftEquipmentId;
                                                                }

                                                                stop.FlightSegmentId = flightSegment.FlightSegmentId;
                                                                context.FlightStops.Add(stop);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }


                    if (model.Warnings != null)
                    {
                        foreach (var item in model.Warnings)
                        {
                            Issue issue = new Issue();
                            issue.Code = item.Code;
                            issue.Detail = item.Detail;
                            issue.FlightOffersId = flightOffers.FlightOffersId;
                            issue.Status = item.Status;
                            issue.Title = item.Title;

                            IssueSource issueSource = new IssueSource();
                            if (item.Source != null)
                            {
                                issueSource.Example = item.Source.Example;
                                issueSource.Parameter = item.Source.Parameter;
                                issueSource.Pointer = item.Source.Pointer;

                                context.IssueSources.Add(issueSource);
                                issue.SourceId = issueSource.IssueSourceId;
                            }

                            context.Issues.Add(issue);
                        }
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Flights", e);
                }
            }
        }
    }
}
