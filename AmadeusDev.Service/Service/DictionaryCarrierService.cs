using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Service.IService;

namespace Jasarsoft.AmadeusDev.Service.Service
{
    public class DictionaryCarrierService : IDictionaryCarrierService
    {
        private readonly IUnitOfWork unitOfWork;

        public DictionaryCarrierService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


    }
}
