using System;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;


namespace Jasarsoft.AmadeusDev.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IAircraftRepository Aircrafts { get; }
        ICarrierRepository Carriers { get; }
        ICurrencyRepository Currencies { get; }
        IFlightEndPointRepository FlightEndPoints { get; }
        IFlightOfferRepository FlightOffers { get; }
        IFlightRepository Flights { get; }
        IFlightSegmentRepository FlightSegments { get; }
        IFlightStopRepository FlightStops { get; }
        ILocationRepository Locations { get; }
        IOfferItemRepository OfferItems { get; }
        IOperationRepository Operations { get; }
        IPriceRepository Prices { get; }
        IPricingDetailRepository PricingDetails { get; }
        ISegmentRepository Segments { get; }
        IServiceRepository Services { get; }

        IAddressRepository Addresses { get; }
        IDistanceRepository Distances { get; }        
    }
}
