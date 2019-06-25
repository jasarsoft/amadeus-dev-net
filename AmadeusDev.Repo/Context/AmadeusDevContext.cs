using System;
using System.Linq;

using Jasarsoft.AmadeusDev.Data.Flights;
using Jasarsoft.AmadeusDev.Data.Airports;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Jasarsoft.AmadeusDev.Repo.Context
{
    public class AmadeusDevContext : DbContext
    {
        public AmadeusDevContext(DbContextOptions<AmadeusDevContext> options) : base(options) { }

        public virtual DbSet<AircraftEquipment> AircraftEquipments { get; set; }
        public virtual DbSet<Defaults> Defaults { get; set; }
        public virtual DbSet<Dictionaries> Dictionaries { get; set; }
        public virtual DbSet<DictionaryEntry> DictionaryEntries { get; set; }
        public virtual DbSet<FlightEndPoint> FlightEndPoints { get; set; }
        public virtual DbSet<FlightOffer> FlightOffer { get; set; }
        public virtual DbSet<FlightOffers> FlightOffers { get; set; }
        public virtual DbSet<FlightSegment> FlightSegments { get; set; }
        public virtual DbSet<FlightStop> FlightStops { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<IssueSource> IssueSources { get; set; }
        public virtual DbSet<Links> Links { get; set; }
        public virtual DbSet<LocationEntry> LocationEntries { get; set; }
        public virtual DbSet<Meta> Metas { get; set; }
        public virtual DbSet<OfferItem> OfferItems { get; set; }
        public virtual DbSet<OperatingFlight> OperatingFlights { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PricingDetail> PricingDetails { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Analytics> Analytics { get; set; }
        public virtual DbSet<CollectionLinks> CollectionLinks { get; set; }
        public virtual DbSet<CollectionMeta> CollectionMeta { get; set; }
        public virtual DbSet<Distance> Distance { get; set; }
        public virtual DbSet<GeoCode> GeoCode { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Self> Self { get; set; }
        public virtual DbSet<Success> Success { get; set; }
        public virtual DbSet<Travelers> Travelers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(x => {
                    x.DeleteBehavior = DeleteBehavior.Restrict;
                });

            modelBuilder.Entity<Self>()
                .Property(e => e.Methods)
                .HasConversion(
                    v => String.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<GeoCode>()
                .Property(p => p.Latitude)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<GeoCode>()
                .Property(p => p.Longitude)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Location>()
                .Property(p => p.Relevance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Travelers>()
                .Property(p => p.Score)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<CollectionMeta>()
                .Property(x => x.Count)
                .HasDefaultValue(0);

            modelBuilder.Entity<Self>()
                .Property(x => x.Count)
                .HasDefaultValue(0);
        }
    }
}
