using System;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;


namespace Jasarsoft.AmadeusDev.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IAircraftRepository Aircrafts { get; }
        IDictionaryAircraftRepository DictionaryAircrafts { get; }
        IDictionaryCarrierRepository DictionaryCarriers { get; }
        IDictionaryCurrencyRepository DictionaryCurrencies { get; }
        IDictionaryLocationRepository DictionaryLocations { get; }
        IDictionaryRepository Dictionaries { get; }
        IFlightEndPointRepository FlightEndPoints { get; }
        IFlightOfferRepository FlightOffers { get; }
        IFlightRepository Flights { get; }
        IFlightSegmentRepository FlightSegments { get; }
        IFlightStopRepository FlightStops { get; }
        IOfferItemRepository OfferItems { get; }
        IOperationRepository Operations { get; }
        IPriceRepository Prices { get; }
        IPricingDetailRepository PricingDetails { get; }
        ISegmentRepository Segments { get; }
        IServiceRepository Services { get; }

        IAddressRepository Addresses { get; }
        IDistanceRepository Distances { get; }
        ILocationRepository Locations { get; }
    }
}
