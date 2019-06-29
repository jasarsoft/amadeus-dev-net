using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.Models.Airports;
using Jasarsoft.AmadeusDev.Service.IService;

namespace Jasarsoft.AmadeusDev.Service.Service
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Insert(Repo.Models.Airports.Success model)
        {
            if (model == null || model.Data == null) throw new ArgumentNullException();
            //foreach (var item in model.Data)
            //{
            //    if (item.Address == null || item.Analytics.Travelers == null || item.Distance == null || item.GeoCode == null || item.Self == null)
            //        throw new ArgumentNullException();
            //}

            foreach (var item in model.Data)
            {
                unitOfWork.Locations.Insert(item);
            }
        }
    }
}
