using System;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;


namespace Jasarsoft.AmadeusDev.Repo
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly AmadeusDevContext context;
        private readonly IServiceProvider serviceProvider;

        public UnitOfWork(AmadeusDevContext context, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.serviceProvider = serviceProvider;
        }

        private IAircraftEquipmentRepository aircraftEquipmentsRepository;
        public IAircraftEquipmentRepository AircraftEquipments => aircraftEquipmentsRepository ?? (aircraftEquipmentsRepository = serviceProvider.GetService<IAircraftEquipmentRepository>());

        private IDefaultsRepository defaultsRepository;
        public IDefaultsRepository Defaults => defaultsRepository ?? (defaultsRepository = serviceProvider.GetService<IDefaultsRepository>());

        private IDictionariesRepository dictionariesRepository;
        public IDictionariesRepository Dictionaries => dictionariesRepository ?? (dictionariesRepository = serviceProvider.GetService<IDictionariesRepository>());

        private IDictionaryEntryRepository dictionaryEntryRepository;
        public IDictionaryEntryRepository DictionaryEntries => dictionaryEntryRepository ?? (dictionaryEntryRepository = serviceProvider.GetService<IDictionaryEntryRepository>());

        private IFlightEndPointRepository flightEndPointRepository;
        public IFlightEndPointRepository FlightEndPoints => flightEndPointRepository ?? (flightEndPointRepository = serviceProvider.GetService<IFlightEndPointRepository>());

        private IFlightOfferRepository flightOfferRepository;
        public IFlightOfferRepository FlightOffer => flightOfferRepository ?? (flightOfferRepository = serviceProvider.GetService<IFlightOfferRepository>());

        private IFlightOffersRepository flightOffersRepository;
        public IFlightOffersRepository FlightOffers => flightOffersRepository ?? (flightOffersRepository = serviceProvider.GetService<IFlightOffersRepository>());

        private IFlightSegmentRepository flightSegmentRepository;
        public IFlightSegmentRepository FlightSegments => flightSegmentRepository ?? (flightSegmentRepository = serviceProvider.GetService<IFlightSegmentRepository>());

        private IFlightStopRepository flightStopRepository;
        public IFlightStopRepository FlightStops => flightStopRepository ?? (flightStopRepository = serviceProvider.GetService<IFlightStopRepository>());

        private IIssueRepository issueRepository;
        public IIssueRepository Issues => issueRepository ?? (issueRepository = serviceProvider.GetService<IIssueRepository>());

        private IIssueSourceRepository issueSourceRepository;
        public IIssueSourceRepository IssueSources => issueSourceRepository ?? (issueSourceRepository = serviceProvider.GetService<IIssueSourceRepository>());

        private ILinksRepository linksRepository;
        public ILinksRepository Links => linksRepository ?? (linksRepository = serviceProvider.GetService<ILinksRepository>());

        private ILocationEntryRepository locationEntryRepository;
        public ILocationEntryRepository LocationEntries => locationEntryRepository ?? (locationEntryRepository = serviceProvider.GetService<ILocationEntryRepository>());

        private IMetaRepository metaRepository;
        public IMetaRepository Metas => metaRepository ?? (metaRepository = serviceProvider.GetService<IMetaRepository>());

        private IOfferItemRepository offerItemRepository;
        public IOfferItemRepository OfferItems => offerItemRepository ?? (offerItemRepository = serviceProvider.GetService<IOfferItemRepository>());

        private IOperatingFlightRepository operatingFlightRepository;
        public IOperatingFlightRepository OperatingFlights => operatingFlightRepository ?? (operatingFlightRepository = serviceProvider.GetService<IOperatingFlightRepository>());

        private IPriceRepository priceRepository;
        public IPriceRepository Prices => priceRepository ?? (priceRepository = serviceProvider.GetService<IPriceRepository>());

        private IPricingDetailRepository pricingDetailRepository;
        public IPricingDetailRepository PricingDetails => pricingDetailRepository ?? (pricingDetailRepository = serviceProvider.GetService<IPricingDetailRepository>());

        private ISegmentRepository segmentRepository;
        public ISegmentRepository Segments => segmentRepository ?? (segmentRepository = serviceProvider.GetService<ISegmentRepository>());

        private IServiceRepository serviceRepository;
        public IServiceRepository Services => serviceRepository ?? (serviceRepository = serviceProvider.GetService<IServiceRepository>());

        private IAddressRepository addressRepository;
        public IAddressRepository Address => addressRepository ?? (addressRepository = serviceProvider.GetService<IAddressRepository>());

        private IAnalyticsRepository analyticsRepository;
        public IAnalyticsRepository Analytics => analyticsRepository ?? (analyticsRepository = serviceProvider.GetService<IAnalyticsRepository>());

        private ICollectionLinksRepository collectionLinksRepository;
        public ICollectionLinksRepository CollectionLinks => collectionLinksRepository ?? (collectionLinksRepository = serviceProvider.GetService<ICollectionLinksRepository>());

        private ICollectionMetaRepository collectionMetaRepository;
        public ICollectionMetaRepository CollectionMeta => collectionMetaRepository ?? (collectionMetaRepository = serviceProvider.GetService<ICollectionMetaRepository>());

        private IDistanceRepository distanceRepository;
        public IDistanceRepository Distances => distanceRepository ?? (distanceRepository = serviceProvider.GetService<IDistanceRepository>());

        private IGeoCodeRepository geoCodeRepository;
        public IGeoCodeRepository GeoCodes => geoCodeRepository ?? (geoCodeRepository = serviceProvider.GetService<IGeoCodeRepository>());

        private ILocationRepository locationRepository;
        public ILocationRepository Locations => locationRepository ?? (locationRepository = serviceProvider.GetService<ILocationRepository>());

        private ISelfRepository selfRepository;
        public ISelfRepository Selfs => selfRepository ?? (selfRepository = serviceProvider.GetService<ISelfRepository>());

        private ISuccessRepository successRepository;
        public ISuccessRepository Success => successRepository ?? (successRepository = serviceProvider.GetService<ISuccessRepository>());

        private ITravelersRepository travelersRepository;
        public ITravelersRepository Travelers => travelersRepository ?? (travelersRepository = serviceProvider.GetService<ITravelersRepository>());

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
