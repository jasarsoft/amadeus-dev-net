using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightStopRepository : IRepository<FlightStop, int>
    {
        int Insert(FlightStop model);

        Task<int> InsertAsync(FlightStop model);
    }
}
