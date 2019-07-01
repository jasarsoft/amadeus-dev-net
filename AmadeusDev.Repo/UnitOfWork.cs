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

        private ICarrierRepository carrierRepository;
        public ICarrierRepository Carriers => carrierRepository ?? (carrierRepository = serviceProvider.GetService<ICarrierRepository>());

        private ICurrencyRepository currencyRepository;
        public ICurrencyRepository Currencies => currencyRepository ?? (currencyRepository = serviceProvider.GetService<ICurrencyRepository>());

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

        private ILocationRepository locationRepository;
        public ILocationRepository Locations => locationRepository ?? (locationRepository = serviceProvider.GetService<ILocationRepository>());

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


        //private IAddressRepository addressRepository;
        //public IAddressRepository Addresses => addressRepository ?? (addressRepository = serviceProvider.GetService<IAddressRepository>());

        //private IDistanceRepository distanceRepository;
        //public IDistanceRepository Distances => distanceRepository ?? (distanceRepository = serviceProvider.GetService<IDistanceRepository>());
        

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
