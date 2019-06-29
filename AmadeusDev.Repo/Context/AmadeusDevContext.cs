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
        //flight schema
        public virtual DbSet<Aircraft> Aircraft { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Dictionary> Dictionaries { get; set; }
        public virtual DbSet<DictionaryAircraft> DictionaryAircrafts { get; set; }
        public virtual DbSet<DictionaryCarrier> DictionaryCarriers { get; set; }
        public virtual DbSet<DictionaryCurrency> DictionaryCurrencies { get; set; }
        public virtual DbSet<DictionaryLocation> DictionaryLocations { get; set; }
        public virtual DbSet<FlightEndPoint> FlightEndPoints { get; set; }
        public virtual DbSet<FlightOffer> FlightOffer { get; set; }
        public virtual DbSet<FlightOperation> FlightOperations { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSegment> FlightSegments { get; set; }
        public virtual DbSet<FlightStop> FlightStops { get; set; }
        public virtual DbSet<OfferItem> OfferItems { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PricingDetail> PricingDetails { get; set; }
        public virtual DbSet<Segment> Segments { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        //airport schema
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Distance> Distances { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

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

            modelBuilder.Entity<Location>()
                .Property(p => p.Latitude)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Location>()
                .Property(p => p.Longitude)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Location>()
                .Property(p => p.Score)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Location>()
                .Property(p => p.Relevance)
                .HasColumnType("decimal(18,2)");
        }
    }
}
