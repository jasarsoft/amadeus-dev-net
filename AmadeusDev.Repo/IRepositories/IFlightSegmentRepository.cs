using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface IFlightSegmentRepository : IRepository<FlightSegment, int>
    {
        IEnumerable<FlightSegment> GetByDepartureByIata(string code);
        IEnumerable<FlightSegment> GetByArrivalIata(string code);
        IEnumerable<FlightSegment> GetFlightSegmentsByDate(string date);

        Task<IEnumerable<FlightSegment>> GetByDepartureByIataAsync(string code);
        Task<IEnumerable<FlightSegment>> GetByArrivalIataAsync(string code);
        int Insert(FlightSegment model);
    }
}
