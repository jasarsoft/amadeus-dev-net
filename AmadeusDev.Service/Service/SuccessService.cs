using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Jasarsoft.AmadeusDev.Service.IService;

namespace Jasarsoft.AmadeusDev.Service.Service
{
    public class SuccessService : ISuccessService
    {
        private readonly IUnitOfWork unitOfWork;

        public SuccessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        
        public Success ResponseFromServer(string keyword, int limit = 15)
        {
            string uri = String.Format("https://test.api.amadeus.com/v1/reference-data/locations?subType=AIRPORT,CITY&keyword={0}&page[limit]={1}", keyword.ToLower(), limit.ToString());

            string get = Server.Get(uri, Server.GetToken());

#if DEBUG
            System.Diagnostics.Debug.WriteLine("\nRESPONSE FROM SERVER: GET");
            System.Diagnostics.Debug.WriteLine(get);
#endif
            return JsonConvert.DeserializeObject<Success>(get);
        }

        public void Insert(Success model)
        {
            if (model == null) throw new ArgumentNullException();
            unitOfWork.Success.InsertSuccess(model);
        }

        public async Task<int> InsertAsync(Success model)
        {
            if (model == null) throw new ArgumentNullException();
            return await unitOfWork.Success.InsertSuccessAsync(model);
        }
    }
}
