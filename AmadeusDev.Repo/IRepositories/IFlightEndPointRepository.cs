using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightEndPointRepository : IRepository<FlightEndPoint, int>
    {
        int Insert(FlightEndPoint model);

        Task<int> InsertAsync(FlightEndPoint model);
    }
}
