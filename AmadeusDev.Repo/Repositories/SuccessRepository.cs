using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Jasarsoft.AmadeusDev.Data.Airports;
using Jasarsoft.AmadeusDev.Repo.Context;
using Jasarsoft.AmadeusDev.Repo.IRepositories;
using static Jasarsoft.AmadeusDev.Repo.Helper.Enumerations;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jasarsoft.AmadeusDev.Repo.Repositories
{
    public class SuccessRepository : Repository<Success, int>, ISuccessRepository
    {
        public SuccessRepository(AmadeusDevContext context) : base(context) { }

        public override IEnumerable<Success> SortAndGetRange<TKey>(int start, int take, Expression<Func<Success, TKey>> predicate, OrderBy order)
        {
            return order == OrderBy.ASC
                ? entity.Include(x => x.Meta)
                        .ThenInclude(i => i.Links)
                        .Include(x => x.Data)
                        .OrderBy(predicate)
                        .Skip(start)
                        .Take(take)
                : entity.Include(x => x.Meta)
                        .ThenInclude(i => i.Links)
                        .Include(x => x.Data)
                        .OrderBy(predicate)
                        .Skip(start)
                        .Take(take);

        }

        public IEnumerable<Success> GetAndSortWithFilters<TKey>(int start, int take, Expression<Func<Success, TKey>> predicate, OrderBy order, string departure, string arrival)
        {
            var query = entity.Include(x => x.Meta)
                .ThenInclude(r => r.Links)
                .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
                    .ThenInclude(e => e.Address)
                .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
                    .ThenInclude(e => e.Analytics)
                .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
                    .ThenInclude(a => a.Distance)
                .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
                    .ThenInclude(a => a.GeoCode)
                .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
                    .ThenInclude(s => s.Self)
                .Skip(start)
                .Take(take)
                .AsQueryable();

            //if (!String.IsNullOrEmpty(departure))
            //{
            //    query = query.Where(a => a.Data.AsEnumerable().Where(e => e.Name == "aa"))
            //}
            //else
            //{
            //    query = entity.Include(x => x.Meta)
            //                  .ThenInclude(r => r.Links)
            //                  .Include(d => d.Data.Where(q => q.SuccessId == d.SuccessId))
            //                  .Skip(start)
            //                  .Take(take)
            //                  .AsQueryable();
            //}



            query = order == OrderBy.ASC
                    ? query.OrderBy(predicate)
                    : query.OrderByDescending(predicate);

            return query.ToList();
        }

        private async Task<int> InsertSuccessAsyncOld(Success model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    CollectionLinks links = new CollectionLinks
                    {
                        First = model.Meta.Links.First,
                        Last = model.Meta.Links.Last,
                        Next = model.Meta.Links.Next,
                        Previous = model.Meta.Links.Previous,
                        Self = model.Meta.Links.Self,
                        Up = model.Meta.Links.Up,
                    };
                    await context.CollectionLinks.AddAsync(links);

                    CollectionMeta meta = new CollectionMeta
                    {
                        Count = model.Meta.Count,
                        LinksId = links.LinksId,
                    };
                    await context.CollectionMeta.AddAsync(meta);

                    Success success = new Success
                    {
                        MetaId = meta.MetaId,
                    };
                    await context.Success.AddAsync(success);

                    foreach (var item in model.Data)
                    {
                        Self self = new Self
                        {
                            Count = item.Self.Methods.Count,
                            Href = item.Self.Href,
                            Methods = item.Self.Methods,
                        };
                        await context.Self.AddAsync(self);

                        GeoCode geo = new GeoCode
                        {
                            Latitude = item.GeoCode.Latitude,
                            Longitude = item.GeoCode.Longitude,
                        };
                        await context.GeoCode.AddAsync(geo);

                        Address address = new Address
                        {
                            CityCode = item.Address.CityCode,
                            CityName = item.Address.CityName,
                            CountryCode = item.Address.CountryCode,
                            CountryName = item.Address.CountryName,
                            RegionCode = item.Address.RegionCode,
                            StateCode = item.Address.StateCode,
                        };
                        await context.Address.AddAsync(address);

                        Distance distance = new Distance
                        {
                            Unit = item.Distance.Unit,
                            Value = item.Distance.Value,
                        };
                        await context.Distance.AddAsync(distance);

                        Travelers travelers = new Travelers
                        {
                            Score = item.Analytics.Travelers.Score,
                        };
                        await context.Travelers.AddAsync(travelers);

                        Analytics analytics = new Analytics
                        {
                            TravelersId = travelers.TravelersId,
                        };
                        await context.Analytics.AddAsync(analytics);

                        Location location = new Location
                        {
                            AddressId = address.AdressId,
                            AnalyticsId = analytics.AnalyticsId,
                            DetailedName = item.DetailedName,
                            DistanceId = distance.DistanceId,
                            GeoCodeId = geo.GeoCodeId,
                            IataCode = item.IataCode,
                            Id = item.Id,
                            Name = item.Name,
                            Relevance = item.Relevance,
                            SelfId = self.SelfId,
                            SubType = item.SubType,
                            SuccessId = success.SuccessId,
                            TimeZoneOffset = item.TimeZoneOffset,
                            Type = item.Type,
                        };
                        await context.Location.AddAsync(location);
                        context.SaveChanges();
                    }

                    await context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Success", e);
                }
            }

            return 0;
        }

        public void InsertSuccess(Success model)
        {
            if (model == null) throw new ArgumentNullException();
            using (IDbContextTransaction transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Success success = new Success();
                    CollectionMeta meta = new CollectionMeta();
                    CollectionLinks links = new CollectionLinks();

                    if (model.Meta != null && model.Meta.Links != null)
                    {
                        links.First = model.Meta.Links.First;
                        links.Last = model.Meta.Links.Last;
                        links.Next = model.Meta.Links.Next;
                        links.Previous = model.Meta.Links.Previous;
                        links.Self = model.Meta.Links.Self;
                        links.Up = model.Meta.Links.Up;

                        context.CollectionLinks.Add(links);
                        meta.LinksId = links.LinksId;
                    }
                    
                    if (model.Meta != null)
                    {
                        meta.Count = model.Meta.Count;

                        context.CollectionMeta.Add(meta);
                        success.MetaId = meta.MetaId;
                        context.Success.Add(success);
                    }
                                                                                              
                    if (model.Data == null) throw new NullReferenceException();
                    foreach (var item in model.Data)
                    {
                        Location location = new Location();

                        Self self = new Self();
                        if (item.Self != null)
                        {
                            self.Count = item.Self.Methods.Count;
                            self.Href = item.Self.Href;
                            self.Methods = item.Self.Methods;

                            context.Self.Add(self);
                            location.SelfId = self.SelfId;
                        };

                        GeoCode geo = new GeoCode();
                        if (item.GeoCode != null)
                        {
                            geo.Latitude = item.GeoCode.Latitude;
                            geo.Longitude = item.GeoCode.Longitude;

                            context.GeoCode.Add(geo);
                            location.GeoCodeId = geo.GeoCodeId;
                        };

                        Address address = new Address();
                        if (item.Address != null)
                        {
                            address.CityCode = item.Address.CityCode;
                            address.CityName = item.Address.CityName;
                            address.CountryCode = item.Address.CountryCode;
                            address.CountryName = item.Address.CountryName;
                            address.RegionCode = item.Address.RegionCode;
                            address.StateCode = item.Address.StateCode;

                            context.Address.Add(address);
                            location.AddressId = address.AdressId;
                        };
                        
                        Distance distance = new Distance();
                        if (item.Distance != null)
                        {
                            distance.Unit = item.Distance.Unit;
                            distance.Value = item.Distance.Value;

                            context.Distance.Add(distance);
                            location.DistanceId = distance.DistanceId;
                        }

                        Analytics analytics = new Analytics();
                        Travelers travelers = new Travelers();
                        if (item.Analytics != null && item.Analytics.Travelers != null)
                        {
                            travelers.Score = item.Analytics.Travelers.Score;

                            context.Travelers.Add(travelers);
                            analytics.TravelersId = travelers.TravelersId;
                            context.Analytics.Add(analytics);
                            location.AnalyticsId = analytics.AnalyticsId;
                        };
                        
                        location.DetailedName = item.DetailedName;
                        location.IataCode = item.IataCode;
                        location.Id = item.Id;
                        location.Name = item.Name;
                        location.Relevance = item.Relevance;
                        location.SubType = item.SubType;
                        location.TimeZoneOffset = item.TimeZoneOffset;
                        location.Type = item.Type;
                        location.SuccessId = success.SuccessId;
                       
                        context.Location.Add(location);
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Success", e);
                }
            }
        }

        public async Task<int> InsertSuccessAsync(Success model)
        {
            using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    Success success = new Success();
                    CollectionMeta meta = new CollectionMeta();
                    CollectionLinks links = new CollectionLinks();

                    if (model.Meta != null && model.Meta.Links != null)
                    {
                        links.First = model.Meta.Links.First;
                        links.Last = model.Meta.Links.Last;
                        links.Next = model.Meta.Links.Next;
                        links.Previous = model.Meta.Links.Previous;
                        links.Self = model.Meta.Links.Self;
                        links.Up = model.Meta.Links.Up;

                        await context.CollectionLinks.AddAsync(links);
                        meta.LinksId = links.LinksId;
                    }

                    if (model.Meta != null)
                    {
                        meta.Count = model.Meta.Count;

                        await context.CollectionMeta.AddAsync(meta);
                        success.MetaId = meta.MetaId;
                        await context.Success.AddAsync(success);
                    }

                    if (model.Data == null) throw new NullReferenceException();
                    foreach (var item in model.Data)
                    {
                        Location location = new Location();

                        Self self = new Self();
                        if (item.Self != null)
                        {
                            self.Count = item.Self.Methods.Count;
                            self.Href = item.Self.Href;
                            self.Methods = item.Self.Methods;

                            await context.Self.AddAsync(self);
                            location.SelfId = self.SelfId;
                        };

                        GeoCode geo = new GeoCode();
                        if (item.GeoCode != null)
                        {
                            geo.Latitude = item.GeoCode.Latitude;
                            geo.Longitude = item.GeoCode.Longitude;

                            await context.GeoCode.AddAsync(geo);
                            location.GeoCodeId = geo.GeoCodeId;
                        };

                        Address address = new Address();
                        if (item.Address != null)
                        {
                            address.CityCode = item.Address.CityCode;
                            address.CityName = item.Address.CityName;
                            address.CountryCode = item.Address.CountryCode;
                            address.CountryName = item.Address.CountryName;
                            address.RegionCode = item.Address.RegionCode;
                            address.StateCode = item.Address.StateCode;

                            await context.Address.AddAsync(address);
                            location.AddressId = address.AdressId;
                        };

                        Distance distance = new Distance();
                        if (item.Distance != null)
                        {
                            distance.Unit = item.Distance.Unit;
                            distance.Value = item.Distance.Value;

                            await context.Distance.AddAsync(distance);
                            location.DistanceId = distance.DistanceId;
                        }

                        Analytics analytics = new Analytics();
                        Travelers travelers = new Travelers();
                        if (item.Analytics != null && item.Analytics.Travelers != null)
                        {
                            travelers.Score = item.Analytics.Travelers.Score;

                            await context.Travelers.AddAsync(travelers);
                            analytics.TravelersId = travelers.TravelersId;
                            await context.Analytics.AddAsync(analytics);
                            location.AnalyticsId = analytics.AnalyticsId;
                        };

                        location.DetailedName = item.DetailedName;
                        location.IataCode = item.IataCode;
                        location.Id = item.Id;
                        location.Name = item.Name;
                        location.Relevance = item.Relevance;
                        location.SubType = item.SubType;
                        location.TimeZoneOffset = item.TimeZoneOffset;
                        location.Type = item.Type;
                        location.SuccessId = success.SuccessId;

                        await context.Location.AddAsync(location);
                    }

                    int result = await context.SaveChangesAsync();
                    transaction.Commit();
                    return result;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DbUpdateException("Insert Success Async", e);
                }
            }
        }

        public void InsertSuccess1(Success model)
        {
  
            CollectionLinks links = new CollectionLinks
            {
                First = model.Meta.Links.First,
                Last = model.Meta.Links.Last,
                Next = model.Meta.Links.Next,
                Previous = model.Meta.Links.Previous,
                Self = model.Meta.Links.Self,
                Up = model.Meta.Links.Up,
            };
            context.CollectionLinks.Add(links);

            CollectionMeta meta = new CollectionMeta
            {
                Count = model.Meta.Count,
                LinksId = links.LinksId,
            };
            context.CollectionMeta.Add(meta);

            Success success = new Success
            {
                MetaId = meta.MetaId,
            };
            context.Success.Add(success);

            context.SaveChanges();


            List<Self> selfs = new List<Self>();
            int i = 0;
            foreach (var item in model.Data)
            {
                selfs.Add(new Self
                {
                    Count = item.Self.Methods.Count,
                    Href = item.Self.Href,
                    Methods = item.Self.Methods,
                });
                context.Self.Add(selfs[i++]);
            }
            context.SaveChanges();


            List<GeoCode> geos = new List<GeoCode>();
            i = 0;
            foreach (var item in model.Data)
            {
                geos.Add(new GeoCode
                {
                    Latitude = item.GeoCode.Latitude,
                    Longitude = item.GeoCode.Longitude,
                });
                context.GeoCode.Add(geos[i++]);
            }
            context.SaveChanges();

            List<Address> address = new List<Address>();
            i = 0;
            foreach (var item in model.Data)
            {
                address.Add(new Address
                {
                    CityCode = item.Address.CityCode,
                    CityName = item.Address.CityName,
                    CountryCode = item.Address.CountryCode,
                    CountryName = item.Address.CountryName,
                    RegionCode = item.Address.RegionCode,
                    StateCode = item.Address.StateCode,
                });
                context.Address.Add(address[i++]);
            }
            context.SaveChanges();

            List<Distance> distances = new List<Distance>();
            i = 0;
            foreach (var item in model.Data)
            {
                if (item.Distance != null)
                {
                    distances.Add(new Distance
                    {
                        Unit = item.Distance.Unit,
                        Value = item.Distance.Value,
                    });
                    context.Distance.Add(distances[i++]);
                }
            }
            context.SaveChanges();


            List<Travelers> travelers = new List<Travelers>();
            i = 0;
            foreach (var item in model.Data)
            {
                if (item.Analytics.Travelers != null)
                {
                    travelers.Add(new Travelers
                    {
                        Score = item.Analytics.Travelers.Score,
                    });
                    context.Travelers.Add(travelers[i++]);
                }
            }
            context.SaveChanges();

            List<Analytics> analytics = new List<Analytics>();
            i = 0;
            foreach (var item in model.Data)
            {
                if (item.Analytics != null)
                {
                    analytics.Add(new Analytics
                    {
                        TravelersId = travelers[i].TravelersId,
                    });
                    context.Analytics.Add(analytics[i++]);
                }
            }
            context.SaveChanges();
        }
    }
}
