using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class SegmentRepository : Repository<Segment, int>, ISegmentRepository
    {
        public SegmentRepository(AmadeusDevContext context) : base(context) { }

        public IEnumerable<Segment> GetByServiceId(int serviceId)
        {
            return entity
                .Include(x => x.FlightSegment)
                    .ThenInclude(x => x.Aircraft)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Arrival)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Departure)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Operating)
                .Include(x => x.PricingDetailPerAdult)
                .Include(x => x.PricingDetailPerChild)
                .Include(x => x.PricingDetailPerInfant)
                .Include(x => x.PricingDetailPerSenior)
                .Where(x => x.ServiceId == serviceId)
                .AsNoTracking()
                .ToList();
        }
    }
}
