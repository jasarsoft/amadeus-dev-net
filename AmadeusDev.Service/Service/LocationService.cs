using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo;
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


    }
}
