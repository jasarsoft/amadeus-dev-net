using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Airports;

namespace Jasarsoft.AmadeusDev.Service.IService
{
    public interface ISuccessService
    {
        void Insert(Success model);
        Task<int> InsertAsync(Success mode);

        Success ResponseFromServer(string keyword, int limit);
    }
}
