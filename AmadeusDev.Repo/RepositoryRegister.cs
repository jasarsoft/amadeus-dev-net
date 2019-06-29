﻿using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jasarsoft.AmadeusDev.Repo
{
    public static class RepositoryRegister
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<IAircraftRepository, AircraftRepository>();
            service.AddTransient<IDictionaryAircraftRepository, DictionaryAircraftRepository>();
            service.AddTransient<IDictionaryCarrierRepository, DictionaryCarrierRepository>();
            service.AddTransient<IDictionaryCurrencyRepository, DictionaryCurrencyRepository>();
            service.AddTransient<IDictionaryLocationRepository, DictionaryLocationRepository>();
            service.AddTransient<IDictionaryRepository, DictionaryRepository>();            
            service.AddTransient<IFlightEndPointRepository, FlightEndPointRepository>();
            service.AddTransient<IFlightOfferRepository, FlightOfferRepository>();
            service.AddTransient<IFlightRepository, FlightRepository>();
            service.AddTransient<IFlightSegmentRepository, FlightSegmentRepository>();
            service.AddTransient<IFlightStopRepository, FlightStopRepository>();            
            service.AddTransient<IOfferItemRepository, OfferItemRepository>();
            service.AddTransient<IOperationRepository, OperationRepository>();
            service.AddTransient<IPriceRepository, PriceRepository>();
            service.AddTransient<IPricingDetailRepository, PricingDetailRepository>();
            service.AddTransient<ISegmentRepository, SegmentRepository>();
            service.AddTransient<IServiceRepository, ServiceRepository>();

            service.AddTransient<IAddressRepository, AddressRepository>();
            service.AddTransient<IDistanceRepository, DistanceRepository>();
            service.AddTransient<ILocationRepository, LocationRepository>();
        }
    }
}
