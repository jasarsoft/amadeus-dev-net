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
            services.AddTransient<IAircraftService, AircraftService>();
            services.AddTransient<IDictionaryAircraftService, DictionaryAircraftService>();
            services.AddTransient<IDictionaryCarrierService, DictionaryCarrierService>();
            services.AddTransient<IDictionaryCurrencyService, DictionaryCurrencyService>();
            services.AddTransient<IDictionaryLocationService, DictionaryLocationService>();
            services.AddTransient<IDictionaryService, DictionaryService>();            
            services.AddTransient<IFlightEndPointService, FlightEndPointService>();
            services.AddTransient<IFlightOfferService, FlightOfferService>();
            services.AddTransient<IFlightService, FlightService>();
            services.AddTransient<IFlightSegmentService, FlightSegmentService>();
            services.AddTransient<IFlightStopService, FlightStopService>();
            services.AddTransient<IOfferItemService, OfferItemService>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IPricingDetailService, PricingDetailService>();
            services.AddTransient<ISegmentService, SegmentService>();
            services.AddTransient<IServiceService, ServiceService>();

            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IDistanceService, DistanceService>();
            services.AddTransient<ILocationService, LocationService>();
        }
    }
}
