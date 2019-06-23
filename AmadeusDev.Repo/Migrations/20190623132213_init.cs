using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmadeusDev.Repo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftEquipments",
                columns: table => new
                {
                    AircraftEquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftEquipments", x => x.AircraftEquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                columns: table => new
                {
                    DefaultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NonStop = table.Column<bool>(nullable: true),
                    Adults = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defaults", x => x.DefaultId);
                });

            migrationBuilder.CreateTable(
                name: "DictionaryEntries",
                columns: table => new
                {
                    DictionaryEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryEntries", x => x.DictionaryEntryId);
                });

            migrationBuilder.CreateTable(
                name: "FlightEndPoints",
                columns: table => new
                {
                    FlightEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IataCode = table.Column<string>(nullable: true),
                    Terminal = table.Column<string>(nullable: true),
                    At = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightEndPoints", x => x.FlightEndPointId);
                });

            migrationBuilder.CreateTable(
                name: "Issue_Sources",
                columns: table => new
                {
                    IssueSourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pointer = table.Column<string>(nullable: true),
                    Parameter = table.Column<string>(nullable: true),
                    Example = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue_Sources", x => x.IssueSourceId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Self = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                });

            migrationBuilder.CreateTable(
                name: "LocationEntries",
                columns: table => new
                {
                    LocationEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEntries", x => x.LocationEntryId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingFlights",
                columns: table => new
                {
                    OperatingFlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierCode = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingFlights", x => x.OperatingFlightId);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
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
                name: "Metas",
                columns: table => new
                {
                    MetaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinksId = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    DefaultsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.MetaId);
                    table.ForeignKey(
                        name: "FK_Metas_Defaults_DefaultsId",
                        column: x => x.DefaultsId,
                        principalTable: "Defaults",
                        principalColumn: "DefaultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Metas_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    DictionaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarriersId = table.Column<int>(nullable: true),
                    CurrenciesId = table.Column<int>(nullable: true),
                    AircraftId = table.Column<int>(nullable: true),
                    LocationsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.DictionaryId);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryEntries_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "DictionaryEntries",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryEntries_CarriersId",
                        column: x => x.CarriersId,
                        principalTable: "DictionaryEntries",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryEntries_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalTable: "DictionaryEntries",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_LocationEntries_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "LocationEntries",
                        principalColumn: "LocationEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightSegments",
                columns: table => new
                {
                    FlightSegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartureId = table.Column<int>(nullable: true),
                    ArrivalId = table.Column<int>(nullable: true),
                    CarrierCode = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    AircraftId = table.Column<int>(nullable: true),
                    OperatingId = table.Column<int>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSegments", x => x.FlightSegmentId);
                    table.ForeignKey(
                        name: "FK_FlightSegments_AircraftEquipments_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "AircraftEquipments",
                        principalColumn: "AircraftEquipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_FlightEndPoints_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "FlightEndPoints",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_FlightEndPoints_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "FlightEndPoints",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegments_OperatingFlights_OperatingId",
                        column: x => x.OperatingId,
                        principalTable: "OperatingFlights",
                        principalColumn: "OperatingFlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightOffers",
                columns: table => new
                {
                    FlightOfferid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DictionariesId = table.Column<int>(nullable: true),
                    MetaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffers", x => x.FlightOfferid);
                    table.ForeignKey(
                        name: "FK_FlightOffers_Dictionaries_DictionariesId",
                        column: x => x.DictionariesId,
                        principalTable: "Dictionaries",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightOffers_Metas_MetaId",
                        column: x => x.MetaId,
                        principalTable: "Metas",
                        principalColumn: "MetaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightStops",
                columns: table => new
                {
                    FlightStopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IataCode = table.Column<string>(nullable: true),
                    NewAircraftId = table.Column<int>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    ArrivalAt = table.Column<string>(nullable: true),
                    DepartureAt = table.Column<string>(nullable: true),
                    FlightSegmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightStops", x => x.FlightStopId);
                    table.ForeignKey(
                        name: "FK_FlightStops_FlightSegments_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalTable: "FlightSegments",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightStops_AircraftEquipments_NewAircraftId",
                        column: x => x.NewAircraftId,
                        principalTable: "AircraftEquipments",
                        principalColumn: "AircraftEquipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightOffer",
                columns: table => new
                {
                    FlightOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true),
                    FlightOffersFlightOfferid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffer", x => x.FlightOfferId);
                    table.ForeignKey(
                        name: "FK_FlightOffer_FlightOffers_FlightOffersFlightOfferid",
                        column: x => x.FlightOffersFlightOfferid,
                        principalTable: "FlightOffers",
                        principalColumn: "FlightOfferid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    FlightOffersFlightOfferid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issues_FlightOffers_FlightOffersFlightOfferid",
                        column: x => x.FlightOffersFlightOfferid,
                        principalTable: "FlightOffers",
                        principalColumn: "FlightOfferid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issues_Issue_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Issue_Sources",
                        principalColumn: "IssueSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferItems",
                columns: table => new
                {
                    OfferItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PriceId = table.Column<int>(nullable: true),
                    PricePerAdultId = table.Column<int>(nullable: true),
                    PricePerInfantId = table.Column<int>(nullable: true),
                    PricePerChildId = table.Column<int>(nullable: true),
                    PricePerSeniorId = table.Column<int>(nullable: true),
                    FlightOfferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferItems", x => x.OfferItemId);
                    table.ForeignKey(
                        name: "FK_OfferItems_FlightOffer_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalTable: "FlightOffer",
                        principalColumn: "FlightOfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerAdultId",
                        column: x => x.PricePerAdultId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerChildId",
                        column: x => x.PricePerChildId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerInfantId",
                        column: x => x.PricePerInfantId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItems_Prices_PricePerSeniorId",
                        column: x => x.PricePerSeniorId,
                        principalTable: "Prices",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfferItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_OfferItems_OfferItemId",
                        column: x => x.OfferItemId,
                        principalTable: "OfferItems",
                        principalColumn: "OfferItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    SegmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightSegmentId = table.Column<int>(nullable: true),
                    PricingDetailPerAdultId = table.Column<int>(nullable: true),
                    PricingDetailPerInfantId = table.Column<int>(nullable: true),
                    PricingDetailPerChildId = table.Column<int>(nullable: true),
                    PricingDetailPerSeniorId = table.Column<int>(nullable: true),
                    ServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.SegmentId);
                    table.ForeignKey(
                        name: "FK_Segments_FlightSegments_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalTable: "FlightSegments",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerAdultId",
                        column: x => x.PricingDetailPerAdultId,
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerChildId",
                        column: x => x.PricingDetailPerChildId,
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerInfantId",
                        column: x => x.PricingDetailPerInfantId,
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_PricingDetails_PricingDetailPerSeniorId",
                        column: x => x.PricingDetailPerSeniorId,
                        principalTable: "PricingDetails",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_AircraftId",
                table: "Dictionaries",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_CarriersId",
                table: "Dictionaries",
                column: "CarriersId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_CurrenciesId",
                table: "Dictionaries",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_LocationsId",
                table: "Dictionaries",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffer_FlightOffersFlightOfferid",
                table: "FlightOffer",
                column: "FlightOffersFlightOfferid");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_DictionariesId",
                table: "FlightOffers",
                column: "DictionariesId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_MetaId",
                table: "FlightOffers",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_AircraftId",
                table: "FlightSegments",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_ArrivalId",
                table: "FlightSegments",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_DepartureId",
                table: "FlightSegments",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegments_OperatingId",
                table: "FlightSegments",
                column: "OperatingId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStops_FlightSegmentId",
                table: "FlightStops",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStops_NewAircraftId",
                table: "FlightStops",
                column: "NewAircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_FlightOffersFlightOfferid",
                table: "Issues",
                column: "FlightOffersFlightOfferid");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_SourceId",
                table: "Issues",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_DefaultsId",
                table: "Metas",
                column: "DefaultsId");

            migrationBuilder.CreateIndex(
                name: "IX_Metas_LinksId",
                table: "Metas",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_FlightOfferId",
                table: "OfferItems",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PriceId",
                table: "OfferItems",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerAdultId",
                table: "OfferItems",
                column: "PricePerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerChildId",
                table: "OfferItems",
                column: "PricePerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerInfantId",
                table: "OfferItems",
                column: "PricePerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_PricePerSeniorId",
                table: "OfferItems",
                column: "PricePerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_FlightSegmentId",
                table: "Segments",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerAdultId",
                table: "Segments",
                column: "PricingDetailPerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerChildId",
                table: "Segments",
                column: "PricingDetailPerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerInfantId",
                table: "Segments",
                column: "PricingDetailPerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_PricingDetailPerSeniorId",
                table: "Segments",
                column: "PricingDetailPerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ServiceId",
                table: "Segments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OfferItemId",
                table: "Services",
                column: "OfferItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightStops");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Issue_Sources");

            migrationBuilder.DropTable(
                name: "FlightSegments");

            migrationBuilder.DropTable(
                name: "PricingDetails");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AircraftEquipments");

            migrationBuilder.DropTable(
                name: "FlightEndPoints");

            migrationBuilder.DropTable(
                name: "OperatingFlights");

            migrationBuilder.DropTable(
                name: "OfferItems");

            migrationBuilder.DropTable(
                name: "FlightOffer");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "FlightOffers");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "DictionaryEntries");

            migrationBuilder.DropTable(
                name: "LocationEntries");

            migrationBuilder.DropTable(
                name: "Defaults");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
