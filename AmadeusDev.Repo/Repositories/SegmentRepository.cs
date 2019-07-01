using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
            return entity.Include(x => x.FlightSegment)
                    .ThenInclude(x => x.Aircraft)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Arrival)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Arrival)
                        .ThenInclude(x => x.Location)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Carrier)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Departure)
                .Include(x => x.FlightSegment)
                    .ThenInclude(d => d.Departure)
                        .ThenInclude(x => x.Location)
                //.Include(x => x.FlightSegment)
                //    .ThenInclude(d => d.Operation)
                //.Include(x => x.PricingDetailPerAdult)
                //.Include(x => x.PricingDetailPerChild)
                //.Include(x => x.PricingDetailPerInfant)
                //.Include(x => x.PricingDetailPerSenior)
                .Where(x => x.ServiceId == serviceId)
                .AsNoTracking()
                .ToList();
        }

        public int Insert(Segment model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    return model.SegmentId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Segment", e);
                }
            }
        }
    }
}
