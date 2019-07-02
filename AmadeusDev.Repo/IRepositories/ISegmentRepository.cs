using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jasarsoft.AmadeusDev.Data.Flights;

namespace Jasarsoft.AmadeusDev.Repo.IRepositories
{
    public interface ISegmentRepository : IRepository<Segment, int>
    {
        IEnumerable<Segment> GetByServiceId(int serviceId);
        int Insert(Segment model);

        Task<IEnumerable<Segment>> GetByServiceIdAsync(int serviceId);
        Task<int> InsertAsync(Segment model);
    }
}
