using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using Jasarsoft.AmadeusDev.Repo.Helper;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class LocationRepository : Repository<Location, int>, ILocationRepository
    {
        public LocationRepository(AmadeusDevContext context) : base(context) { }


        public int Insert(KeyValuePair<string, string> model)
        {
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Location location = new Location
                    {
                        Code = model.Key,
                        Name = model.Value,
                    };

                    var result = FindByCode(location);

                    if (result == null)
                    {
                        context.Add(location);
                        context.SaveChanges();
                        transaction.Commit();
                        return location.LocationId;
                    }

                    return result.LocationId;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Location", e);
                }
            }
        }

        public Location FindByCode(string code)
        {
            return base.Where(x => x.Code == code).FirstOrDefault();
        }

        public Location FindByCode(Location location)
        {
            return base.Where(x => x.Code == location.Code).FirstOrDefault();
        }

        //public IEnumerable<Location> GetLocationsByName(string keyword)
        //{
        //    var query = entity.Where(x => x.Name.ToLower().Contains(keyword));

        //    return query.ToList();
        //}

        //public override IEnumerable<Location> SortAndGetRange<TKey>(int start, int take, Expression<Func<Location, TKey>> predicate, Enumerations.OrderBy order)
        //{
        //    return order == Enumerations.OrderBy.ASC
        //        ? entity.Include(x => x.Address)
        //                .Include(x => x.Distance)
        //                .OrderBy(predicate)
        //                .Skip(start).Take(take)
        //        : entity.Include(x => x.Address)
        //                .Include(x => x.Distance)
        //                .OrderByDescending(predicate)
        //                .Skip(start).Take(take);
        //}

        //public void Insert(Models.Airports.Location model)
        //{
        //    using (IDbContextTransaction transaction = context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            Location location = model;

        //            context.Addresses.Add(location.Address);
        //            location.AddressId = location.Address.AdressId;

        //            context.Distances.Add(location.Distance);
        //            location.DistanceId = location.Distance.DistanceId;

        //            context.Locations.Add(location);
        //            context.SaveChanges();
        //            transaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            transaction.Rollback();
        //            throw new DbUpdateException("Insert Aircraft location", e);
        //        }
        //    }
        //}
    }
}
