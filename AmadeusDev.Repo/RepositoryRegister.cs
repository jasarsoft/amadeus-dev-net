using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jasarsoft.AmadeusDev.Repo
{
    public static class RepositoryRegister
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            service.AddTransient<IAircraftEquipmentRepository, AircraftEquipmentRepository>();
            service.AddTransient<IDefaultsRepository, DefaultsRepository>();
            service.AddTransient<IDictionariesRepository, DictionariesRepository>();
            service.AddTransient<IDictionaryEntryRepository, DictionaryEntryRespository>();
            service.AddTransient<IFlightEndPointRepository, FlightEndPointRepository>();
            service.AddTransient<IFlightOfferRepository, FlightOfferRepository>();
            service.AddTransient<IFlightOffersRepository, FlightOffersRepository>();
            service.AddTransient<IFlightSegmentRepository, FlightSegmentRepository>();
            service.AddTransient<IFlightStopRepository, FlightStopRepository>();
            service.AddTransient<IIssueRepository, IssueRepository>();
            service.AddTransient<IIssueSourceRepository, IssueSourceRepository>();
            service.AddTransient<ILinksRepository, LinksRepository>();
            service.AddTransient<ILocationEntryRepository, LocationEntryRepository>();
            service.AddTransient<IMetaRepository, MetaRepository>();
            service.AddTransient<IOfferItemRepository, OfferItemRepository>();
            service.AddTransient<IOperatingFlightRepository, OperatingFlightRepository>();
            service.AddTransient<IPriceRepository, PriceRepository>();
            service.AddTransient<IPricingDetailRepository, PricingDetailRepository>();
            service.AddTransient<ISegmentRepository, SegmentRepository>();
            service.AddTransient<IServiceRepository, ServiceRepository>();

            service.AddTransient<IAddressRepository, AddressRepository>();
            service.AddTransient<IAnalyticsRepository, AnalyticsRepository>();
            service.AddTransient<ICollectionLinksRepository, CollectionLinksRepository>();
            service.AddTransient<ICollectionMetaRepository, CollectionMetaRepository>();
            service.AddTransient<IDistanceRepository, DistanceRepository>();
            service.AddTransient<IGeoCodeRepository, GeoCodeRepository>();
            service.AddTransient<ILocationRepository, LocationRepository>();
            service.AddTransient<ISelfRepository, SelfRepository>();
            service.AddTransient<ISuccessRepository, SuccessRepository>();
            service.AddTransient<ITravelersRepository, TravelersRepository>();
        }
    }
}
