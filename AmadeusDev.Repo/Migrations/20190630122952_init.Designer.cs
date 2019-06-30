﻿// <auto-generated />
using System;
using Jasarsoft.AmadeusDev.Repo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmadeusDev.Repo.Migrations
{
    [DbContext(typeof(AmadeusDevContext))]
    [Migration("20190630122952_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Aircraft", b =>
                {
                    b.Property<int>("AircraftId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("AircraftId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Aircrafts","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Carrier", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("CarrierId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Carriers","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("CurrencyId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Currencies","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("DestinationLocationId");

                    b.Property<int>("DestionationId");

                    b.Property<string>("Link");

                    b.Property<int>("OriginId");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("FlightId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DestinationLocationId");

                    b.HasIndex("OriginId");

                    b.ToTable("Flights","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightEndPoint", b =>
                {
                    b.Property<int>("FlightEndPointId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("At");

                    b.Property<int>("LocationId");

                    b.Property<string>("Terminal");

                    b.HasKey("FlightEndPointId");

                    b.HasIndex("LocationId");

                    b.ToTable("FlightEndPoints","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightOffer", b =>
                {
                    b.Property<int>("FlightOfferId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId");

                    b.Property<string>("Id");

                    b.Property<string>("Type");

                    b.HasKey("FlightOfferId");

                    b.HasIndex("FlightId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasFilter("[Id] IS NOT NULL");

                    b.ToTable("FlightOffers","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightSegment", b =>
                {
                    b.Property<int>("FlightSegmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<int>("ArrivalId");

                    b.Property<int>("CarrierId");

                    b.Property<int>("DepartureId");

                    b.Property<string>("Duration");

                    b.Property<string>("Number");

                    b.Property<int>("OperationId");

                    b.HasKey("FlightSegmentId");

                    b.HasIndex("AircraftId");

                    b.HasIndex("ArrivalId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("DepartureId");

                    b.HasIndex("OperationId");

                    b.ToTable("FlightSegments","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightStop", b =>
                {
                    b.Property<int>("FlightStopId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<string>("ArrivalAt");

                    b.Property<int>("CarrierId");

                    b.Property<string>("DepartureAt");

                    b.Property<string>("Duration");

                    b.Property<int>("FlightSegmentId");

                    b.HasKey("FlightStopId");

                    b.HasIndex("AircraftId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("FlightSegmentId");

                    b.ToTable("FlightStops","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("LocationId");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.ToTable("Locations","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.OfferItem", b =>
                {
                    b.Property<int>("OfferItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightOfferId");

                    b.Property<int>("PriceId");

                    b.Property<int?>("PricePerAdultId");

                    b.Property<int?>("PricePerChildId");

                    b.Property<int?>("PricePerInfantId");

                    b.Property<int?>("PricePerSeniorId");

                    b.HasKey("OfferItemId");

                    b.HasIndex("FlightOfferId");

                    b.HasIndex("PriceId");

                    b.HasIndex("PricePerAdultId");

                    b.HasIndex("PricePerChildId");

                    b.HasIndex("PricePerInfantId");

                    b.HasIndex("PricePerSeniorId");

                    b.ToTable("OfferItems","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Operation", b =>
                {
                    b.Property<int>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarrierId");

                    b.Property<string>("Number");

                    b.HasKey("OperationId");

                    b.HasIndex("CarrierId");

                    b.ToTable("Operations","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Total");

                    b.Property<string>("TotalTaxes");

                    b.HasKey("PriceId");

                    b.ToTable("Prices","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.PricingDetail", b =>
                {
                    b.Property<int>("PricingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Availability");

                    b.Property<string>("FareBasis");

                    b.Property<string>("FareClass");

                    b.Property<string>("TravelClass");

                    b.HasKey("PricingDetailId");

                    b.ToTable("PricingDetails","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Segment", b =>
                {
                    b.Property<int>("SegmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightSegmentId");

                    b.Property<int?>("PricingDetailPerAdultId");

                    b.Property<int?>("PricingDetailPerChildId");

                    b.Property<int?>("PricingDetailPerInfantId");

                    b.Property<int?>("PricingDetailPerSeniorId");

                    b.Property<int>("ServiceId");

                    b.HasKey("SegmentId");

                    b.HasIndex("FlightSegmentId");

                    b.HasIndex("PricingDetailPerAdultId");

                    b.HasIndex("PricingDetailPerChildId");

                    b.HasIndex("PricingDetailPerInfantId");

                    b.HasIndex("PricingDetailPerSeniorId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Segments","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OfferItemId");

                    b.HasKey("ServiceId");

                    b.HasIndex("OfferItemId");

                    b.ToTable("Services","Flight");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Flight", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationLocationId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Location", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightEndPoint", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightOffer", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Flight", "Flight")
                        .WithMany("Data")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightSegment", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.FlightEndPoint", "Arrival")
                        .WithMany()
                        .HasForeignKey("ArrivalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.FlightEndPoint", "Departure")
                        .WithMany()
                        .HasForeignKey("DepartureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.FlightStop", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.FlightSegment", "FlightSegment")
                        .WithMany("Stops")
                        .HasForeignKey("FlightSegmentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.OfferItem", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.FlightOffer", "FlightOffer")
                        .WithMany("OfferItems")
                        .HasForeignKey("FlightOfferId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Price", "PricePerAdult")
                        .WithMany()
                        .HasForeignKey("PricePerAdultId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Price", "PricePerChild")
                        .WithMany()
                        .HasForeignKey("PricePerChildId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Price", "PricePerInfant")
                        .WithMany()
                        .HasForeignKey("PricePerInfantId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Price", "PricePerSenior")
                        .WithMany()
                        .HasForeignKey("PricePerSeniorId");
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Operation", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Carrier", "Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Segment", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.FlightSegment", "FlightSegment")
                        .WithMany()
                        .HasForeignKey("FlightSegmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.PricingDetail", "PricingDetailPerAdult")
                        .WithMany()
                        .HasForeignKey("PricingDetailPerAdultId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.PricingDetail", "PricingDetailPerChild")
                        .WithMany()
                        .HasForeignKey("PricingDetailPerChildId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.PricingDetail", "PricingDetailPerInfant")
                        .WithMany()
                        .HasForeignKey("PricingDetailPerInfantId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.PricingDetail", "PricingDetailPerSenior")
                        .WithMany()
                        .HasForeignKey("PricingDetailPerSeniorId");

                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.Service", "Service")
                        .WithMany("Segments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Jasarsoft.AmadeusDev.Data.Flights.Service", b =>
                {
                    b.HasOne("Jasarsoft.AmadeusDev.Data.Flights.OfferItem", "OfferItem")
                        .WithMany("Services")
                        .HasForeignKey("OfferItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
