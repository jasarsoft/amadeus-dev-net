using System;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;


namespace Jasarsoft.AmadeusDev.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IAircraftEquipmentRepository AircraftEquipments { get; }
        IDefaultsRepository Defaults { get; }
        IDictionariesRepository Dictionaries { get; }
        IDictionaryEntryRepository DictionaryEntries { get; }
        IFlightEndPointRepository FlightEndPoints { get; }
        IFlightOfferRepository FlightOffer { get; }
        IFlightOffersRepository FlightOffers { get; }
        IFlightSegmentRepository FlightSegments { get; }
        IFlightStopRepository FlightStops { get; }
        IIssueRepository Issues { get; }
        IIssueSourceRepository IssueSources { get; }
        ILinksRepository Links { get; }
        ILocationEntryRepository LocationEntries { get; }
        IMetaRepository Metas { get; }
        IOfferItemRepository OfferItems { get; }
        IOperatingFlightRepository OperatingFlights { get; }
        IPriceRepository Prices { get; }
        IPricingDetailRepository PricingDetails { get; }
        ISegmentRepository Segments { get; }
        IServiceRepository Services { get; }
    }
}
