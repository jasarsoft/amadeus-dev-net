using Microsoft.Extensions.DependencyInjection;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Service.Service;
using Jasarsoft.AmadeusDev.Service.IService;

namespace Jasarsoft.AmadeusDev.Service
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAircraftEquipmentService, AircraftEquipmentService>();
            services.AddTransient<IDefaultsService, DefaultsService>();
            services.AddTransient<IDictionariesService, DictionariesService>();
            services.AddTransient<IDictionaryEntryService, DictionaryEntryService>();
            services.AddTransient<IFlightEndPointService, FlightEndPointService>();
            services.AddTransient<IFlightOfferService, FlightOfferService>();
            services.AddTransient<IFlightOffersService, FlightOffersService>();
            services.AddTransient<IFlightSegmentService, FlightSegmentService>();
            services.AddTransient<IFlightStopService, FlightStopService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IIssueSourceService, IssueSourceService>();
            services.AddTransient<ILinksService, LinksService>();
            services.AddTransient<ILocationEntryService, LocationEntryService>();
            services.AddTransient<IMetaService, MetaService>();
            services.AddTransient<IOfferItemService, OfferItemService>();
            services.AddTransient<IOperatingFlightService, OperatingFlightService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IPricingDetailService, PricingDetailService>();
            services.AddTransient<ISegmentService, SegmentService>();
            services.AddTransient<IServiceService, ServiceService>();

            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IAnalyticsService, AnalyticsService>();
            services.AddTransient<ICollectionLinksService, CollectionLinksService>();
            services.AddTransient<ICollectionMetaService, CollectionMetaService>();
            services.AddTransient<IDistanceService, DistanceService>();
            services.AddTransient<IGeoCodeService, GeoCodeService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<ISelfService, SelfService>();
            services.AddTransient<ISuccessService, SuccessService>();
            services.AddTransient<ITravelersService, TravelersService>();
        }
    }
}
