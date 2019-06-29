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

        private IAircraftRepository aircraftRepository;
        public IAircraftRepository Aircrafts=> aircraftRepository ?? (aircraftRepository = serviceProvider.GetService<IAircraftRepository>());

        private IDictionaryAircraftRepository dictionaryAirfraftRepository;
        public IDictionaryAircraftRepository DictionaryAircrafts => dictionaryAirfraftRepository ?? (dictionaryAirfraftRepository = serviceProvider.GetService<IDictionaryAircraftRepository>());

        private IDictionaryCarrierRepository dictionaryCarrierRepository;
        public IDictionaryCarrierRepository DictionaryCarriers => dictionaryCarrierRepository ?? (dictionaryCarrierRepository = serviceProvider.GetService<IDictionaryCarrierRepository>());

        private IDictionaryCurrencyRepository dictionaryCurrencyRepository;
        public IDictionaryCurrencyRepository DictionaryCurrencies => dictionaryCurrencyRepository ?? (dictionaryCurrencyRepository = serviceProvider.GetService<IDictionaryCurrencyRepository>());

        private IDictionaryLocationRepository dictionaryLocationRepository;
        public IDictionaryLocationRepository DictionaryLocations => dictionaryLocationRepository ?? (dictionaryLocationRepository = serviceProvider.GetService<IDictionaryLocationRepository>());

        private IDictionaryRepository dictionaryRepository;
        public IDictionaryRepository Dictionaries => dictionaryRepository ?? (dictionaryRepository = serviceProvider.GetService<IDictionaryRepository>());

        private IFlightEndPointRepository flightEndPointRepository;
        public IFlightEndPointRepository FlightEndPoints => flightEndPointRepository ?? (flightEndPointRepository = serviceProvider.GetService<IFlightEndPointRepository>());

        private IFlightOfferRepository flightOfferRepository;
        public IFlightOfferRepository FlightOffers => flightOfferRepository ?? (flightOfferRepository = serviceProvider.GetService<IFlightOfferRepository>());

        private IFlightRepository flightRepository;
        public IFlightRepository Flights=> flightRepository ?? (flightRepository = serviceProvider.GetService<IFlightRepository>());

        private IFlightSegmentRepository flightSegmentRepository;
        public IFlightSegmentRepository FlightSegments => flightSegmentRepository ?? (flightSegmentRepository = serviceProvider.GetService<IFlightSegmentRepository>());

        private IFlightStopRepository flightStopRepository;
        public IFlightStopRepository FlightStops => flightStopRepository ?? (flightStopRepository = serviceProvider.GetService<IFlightStopRepository>());        

        private IOfferItemRepository offerItemRepository;
        public IOfferItemRepository OfferItems => offerItemRepository ?? (offerItemRepository = serviceProvider.GetService<IOfferItemRepository>());

        private IOperationRepository operationRepository;
        public IOperationRepository Operations => operationRepository ?? (operationRepository = serviceProvider.GetService<IOperationRepository>());

        private IPriceRepository priceRepository;
        public IPriceRepository Prices => priceRepository ?? (priceRepository = serviceProvider.GetService<IPriceRepository>());

        private IPricingDetailRepository pricingDetailRepository;
        public IPricingDetailRepository PricingDetails => pricingDetailRepository ?? (pricingDetailRepository = serviceProvider.GetService<IPricingDetailRepository>());

        private ISegmentRepository segmentRepository;
        public ISegmentRepository Segments => segmentRepository ?? (segmentRepository = serviceProvider.GetService<ISegmentRepository>());

        private IServiceRepository serviceRepository;
        public IServiceRepository Services => serviceRepository ?? (serviceRepository = serviceProvider.GetService<IServiceRepository>());


        private IAddressRepository addressRepository;
        public IAddressRepository Addresses => addressRepository ?? (addressRepository = serviceProvider.GetService<IAddressRepository>());

        private IDistanceRepository distanceRepository;
        public IDistanceRepository Distances => distanceRepository ?? (distanceRepository = serviceProvider.GetService<IDistanceRepository>());
        
        private ILocationRepository locationRepository;
        public ILocationRepository Locations => locationRepository ?? (locationRepository = serviceProvider.GetService<ILocationRepository>());


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
