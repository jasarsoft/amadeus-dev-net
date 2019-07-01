using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmadeusDev.Repo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Flight");

            migrationBuilder.CreateTable(
                name: "Aircrafts",
                schema: "Flight",
                columns: table => new
                {
                    AircraftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.AircraftId);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                schema: "Flight",
                columns: table => new
                {
                    CarrierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.CarrierId);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Flight",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "Flight",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                schema: "Flight",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<string>(nullable: true),
                    TotalTaxes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "PricingDetails",
                schema: "Flight",
                columns: table => new
                {
                    PricingDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelClass = table.Column<string>(nullable: true),
                    FareClass = table.Column<string>(nullable: true),
                    Availability = table.Column<int>(nullable: true),
                    FareBasis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingDetails", x => x.PricingDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                schema: "Flight",
                columns: table => new
                {
                    OperationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    CarrierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "Flight",
                        principalTable: "Carriers",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "Flight",
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightEndPoints",
                schema: "Flight",
                columns: table => new
                {
                    FlightEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationId = table.Column<int>(nullable: false),
                    Terminal = table.Column<string>(nullable: true),
                    At = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightEndPoints", x => x.FlightEndPointId);
                    table.ForeignKey(
                        name: "FK_FlightEndPoints_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Flight",
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightOffers",
                schema: "Flight",
                columns: table => new
                {
                    FlightOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    FlightId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffers", x => x.FlightOfferId);
                    table.ForeignKey(
                        name: "FK_FlightOffers_Flights_FlightId",
                        column: x => x.FlightId,
                        principalSchema: "Flight",
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightSegments",
                schema: "Flight",
                columns: table => new
                {
                    FlightSegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartureId = table.Column<int>(nullable: false),
                    ArrivalId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    CarrierId = table.Column<int>(nullable: false),
                    AircraftId = table.Column<int>(nullable: false),
                    OperationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSegments", x => x.FlightSegmentId);
                    table.ForeignKey(
                        name: "FK_FlightSegments_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalSchema: "Flight",
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_FlightEndPoints_ArrivalId",
                        column: x => x.ArrivalId,
                        principalSchema: "Flight",
                        principalTable: "FlightEndPoints",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "Flight",
                        principalTable: "Carriers",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_FlightEndPoints_DepartureId",
                        column: x => x.DepartureId,
                        principalSchema: "Flight",
                        principalTable: "FlightEndPoints",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_Operations_OperationId",
                        column: x => x.OperationId,
                        principalSchema: "Flight",
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferItems",
                schema: "Flight",
                columns: table => new
                {
                    OfferItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriceId = table.Column<int>(nullable: false),
                    PricePerAdultId = table.Column<int>(nullable: true),
                    PricePerInfantId = table.Column<int>(nullable: true),
                    PricePerChildId = table.Column<int>(nullable: true),
                    PricePerSeniorId = table.Column<int>(nullable: true),
                    FlightOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItems", x => x.OfferItemId);
                    table.ForeignKey(
                        name: "FK_OfferItems_FlightOffers_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalSchema: "Flight",
                        principalTable: "FlightOffers",
                        principalColumn: "FlightOfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Flight",
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerAdultId",
                        column: x => x.PricePerAdultId,
                        principalSchema: "Flight",
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerChildId",
                        column: x => x.PricePerChildId,
                        principalSchema: "Flight",
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerInfantId",
                        column: x => x.PricePerInfantId,
                        principalSchema: "Flight",
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerSeniorId",
                        column: x => x.PricePerSeniorId,
                        principalSchema: "Flight",
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightStops",
                schema: "Flight",
                columns: table => new
                {
                    FlightStopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierId = table.Column<int>(nullable: false),
                    AircraftId = table.Column<int>(nullable: false),
                    Duration = table.Column<string>(nullable: true),
                    ArrivalAt = table.Column<string>(nullable: true),
                    DepartureAt = table.Column<string>(nullable: true),
                    FlightSegmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStops", x => x.FlightStopId);
                    table.ForeignKey(
                        name: "FK_FlightStops_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalSchema: "Flight",
                        principalTable: "Aircrafts",
                        principalColumn: "AircraftId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightStops_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalSchema: "Flight",
                        principalTable: "Carriers",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightStops_FlightSegments_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalSchema: "Flight",
                        principalTable: "FlightSegments",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "Flight",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfferItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_OfferItems_OfferItemId",
                        column: x => x.OfferItemId,
                        principalSchema: "Flight",
                        principalTable: "OfferItems",
                        principalColumn: "OfferItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                schema: "Flight",
                columns: table => new
                {
                    SegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightSegmentId = table.Column<int>(nullable: false),
                    PricingDetailPerAdultId = table.Column<int>(nullable: true),
                    PricingDetailPerInfantId = table.Column<int>(nullable: true),
                    PricingDetailPerChildId = table.Column<int>(nullable: true),
                    PricingDetailPerSeniorId = table.Column<int>(nullable: true),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.SegmentId);
                    table.ForeignKey(
                        name: "FK_Segments_FlightSegments_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalSchema: "Flight",
                        principalTable: "FlightSegments",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerAdultId",
                        column: x => x.PricingDetailPerAdultId,
                        principalSchema: "Flight",
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerChildId",
                        column: x => x.PricingDetailPerChildId,
                        principalSchema: "Flight",
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerInfantId",
                        column: x => x.PricingDetailPerInfantId,
                        principalSchema: "Flight",
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerSeniorId",
                        column: x => x.PricingDetailPerSeniorId,
                        principalSchema: "Flight",
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Flight",
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_Code",
                schema: "Flight",
                table: "Aircrafts",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_Code",
                schema: "Flight",
                table: "Carriers",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                schema: "Flight",
                table: "Currencies",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FlightEndPoints_LocationId",
                schema: "Flight",
                table: "FlightEndPoints",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_FlightId",
                schema: "Flight",
                table: "FlightOffers",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_Id",
                schema: "Flight",
                table: "FlightOffers",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CurrencyId",
                schema: "Flight",
                table: "Flights",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_AircraftId",
                schema: "Flight",
                table: "FlightSegments",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_ArrivalId",
                schema: "Flight",
                table: "FlightSegments",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_CarrierId",
                schema: "Flight",
                table: "FlightSegments",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_DepartureId",
                schema: "Flight",
                table: "FlightSegments",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_OperationId",
                schema: "Flight",
                table: "FlightSegments",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStops_AircraftId",
                schema: "Flight",
                table: "FlightStops",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStops_CarrierId",
                schema: "Flight",
                table: "FlightStops",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStops_FlightSegmentId",
                schema: "Flight",
                table: "FlightStops",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Code",
                schema: "Flight",
                table: "Locations",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_FlightOfferId",
                schema: "Flight",
                table: "OfferItems",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PriceId",
                schema: "Flight",
                table: "OfferItems",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerAdultId",
                schema: "Flight",
                table: "OfferItems",
                column: "PricePerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerChildId",
                schema: "Flight",
                table: "OfferItems",
                column: "PricePerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerInfantId",
                schema: "Flight",
                table: "OfferItems",
                column: "PricePerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerSeniorId",
                schema: "Flight",
                table: "OfferItems",
                column: "PricePerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CarrierId",
                schema: "Flight",
                table: "Operations",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_FlightSegmentId",
                schema: "Flight",
                table: "Segments",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerAdultId",
                schema: "Flight",
                table: "Segments",
                column: "PricingDetailPerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerChildId",
                schema: "Flight",
                table: "Segments",
                column: "PricingDetailPerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerInfantId",
                schema: "Flight",
                table: "Segments",
                column: "PricingDetailPerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerSeniorId",
                schema: "Flight",
                table: "Segments",
                column: "PricingDetailPerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ServiceId",
                schema: "Flight",
                table: "Segments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OfferItemId",
                schema: "Flight",
                table: "Services",
                column: "OfferItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightStops",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Segments",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "FlightSegments",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "PricingDetails",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Aircrafts",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "FlightEndPoints",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Operations",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "OfferItems",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Carriers",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "FlightOffers",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Prices",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Flights",
                schema: "Flight");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Flight");
        }
    }
}
