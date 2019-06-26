using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmadeusDev.Repo.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Airports");

            migrationBuilder.EnsureSchema(
                name: "Flights");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Airports",
                columns: table => new
                {
                    AdressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: true),
                    CityCode = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    StateCode = table.Column<string>(nullable: true),
                    RegionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AdressId);
                });

            migrationBuilder.CreateTable(
                name: "CollectionLinks",
                schema: "Airports",
                columns: table => new
                {
                    LinksId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Self = table.Column<string>(nullable: true),
                    Next = table.Column<string>(nullable: true),
                    Previous = table.Column<string>(nullable: true),
                    Last = table.Column<string>(nullable: true),
                    First = table.Column<string>(nullable: true),
                    Up = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionLinks", x => x.LinksId);
                });

            migrationBuilder.CreateTable(
                name: "Distance",
                schema: "Airports",
                columns: table => new
                {
                    DistanceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: true),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distance", x => x.DistanceId);
                });

            migrationBuilder.CreateTable(
                name: "GeoCode",
                schema: "Airports",
                columns: table => new
                {
                    GeoCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCode", x => x.GeoCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Self",
                schema: "Airports",
                columns: table => new
                {
                    SelfId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Href = table.Column<string>(nullable: true),
                    Methods = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Self", x => x.SelfId);
                });

            migrationBuilder.CreateTable(
                name: "Travelers",
                schema: "Airports",
                columns: table => new
                {
                    TravelersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Score = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelers", x => x.TravelersId);
                });

            migrationBuilder.CreateTable(
                name: "AircraftEquipment",
                schema: "Flights",
                columns: table => new
                {
                    AircraftEquipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftEquipment", x => x.AircraftEquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Defaults",
                schema: "Flights",
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
                name: "DictionaryEntry",
                schema: "Flights",
                columns: table => new
                {
                    DictionaryEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryEntry", x => x.DictionaryEntryId);
                });

            migrationBuilder.CreateTable(
                name: "FlightEndPoint",
                schema: "Flights",
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
                    table.PrimaryKey("PK_FlightEndPoint", x => x.FlightEndPointId);
                });

            migrationBuilder.CreateTable(
                name: "IssueSource",
                schema: "Flights",
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
                    table.PrimaryKey("PK_IssueSource", x => x.IssueSourceId);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                schema: "Flights",
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
                name: "LocationEntry",
                schema: "Flights",
                columns: table => new
                {
                    LocationEntryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    subType = table.Column<string>(nullable: true),
                    detailedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationEntry", x => x.LocationEntryId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingFlight",
                schema: "Flights",
                columns: table => new
                {
                    OperatingFlightId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarrierCode = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingFlight", x => x.OperatingFlightId);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "Flights",
                columns: table => new
                {
                    PriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<string>(nullable: true),
                    TotalTaxes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "PricingDetail",
                schema: "Flights",
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
                    table.PrimaryKey("PK_PricingDetail", x => x.PricingDetailId);
                });

            migrationBuilder.CreateTable(
                name: "CollectionMeta",
                schema: "Airports",
                columns: table => new
                {
                    MetaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(nullable: false, defaultValue: 0),
                    LinksId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionMeta", x => x.MetaId);
                    table.ForeignKey(
                        name: "FK_CollectionMeta_CollectionLinks_LinksId",
                        column: x => x.LinksId,
                        principalSchema: "Airports",
                        principalTable: "CollectionLinks",
                        principalColumn: "LinksId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Analytics",
                schema: "Airports",
                columns: table => new
                {
                    AnalyticsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TravelersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analytics", x => x.AnalyticsId);
                    table.ForeignKey(
                        name: "FK_Analytics_Travelers_TravelersId",
                        column: x => x.TravelersId,
                        principalSchema: "Airports",
                        principalTable: "Travelers",
                        principalColumn: "TravelersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meta",
                schema: "Flights",
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
                    table.PrimaryKey("PK_Meta", x => x.MetaId);
                    table.ForeignKey(
                        name: "FK_Meta_Defaults_DefaultsId",
                        column: x => x.DefaultsId,
                        principalSchema: "Flights",
                        principalTable: "Defaults",
                        principalColumn: "DefaultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meta_Links_LinksId",
                        column: x => x.LinksId,
                        principalSchema: "Flights",
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                schema: "Flights",
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
                        name: "FK_Dictionaries_DictionaryEntry_AircraftId",
                        column: x => x.AircraftId,
                        principalSchema: "Flights",
                        principalTable: "DictionaryEntry",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryEntry_CarriersId",
                        column: x => x.CarriersId,
                        principalSchema: "Flights",
                        principalTable: "DictionaryEntry",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_DictionaryEntry_CurrenciesId",
                        column: x => x.CurrenciesId,
                        principalSchema: "Flights",
                        principalTable: "DictionaryEntry",
                        principalColumn: "DictionaryEntryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dictionaries_LocationEntry_LocationsId",
                        column: x => x.LocationsId,
                        principalSchema: "Flights",
                        principalTable: "LocationEntry",
                        principalColumn: "LocationEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightSegment",
                schema: "Flights",
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
                    table.PrimaryKey("PK_FlightSegment", x => x.FlightSegmentId);
                    table.ForeignKey(
                        name: "FK_FlightSegment_AircraftEquipment_AircraftId",
                        column: x => x.AircraftId,
                        principalSchema: "Flights",
                        principalTable: "AircraftEquipment",
                        principalColumn: "AircraftEquipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegment_FlightEndPoint_ArrivalId",
                        column: x => x.ArrivalId,
                        principalSchema: "Flights",
                        principalTable: "FlightEndPoint",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegment_FlightEndPoint_DepartureId",
                        column: x => x.DepartureId,
                        principalSchema: "Flights",
                        principalTable: "FlightEndPoint",
                        principalColumn: "FlightEndPointId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightSegment_OperatingFlight_OperatingId",
                        column: x => x.OperatingId,
                        principalSchema: "Flights",
                        principalTable: "OperatingFlight",
                        principalColumn: "OperatingFlightId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Success",
                schema: "Airports",
                columns: table => new
                {
                    SuccessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MetaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Success", x => x.SuccessId);
                    table.ForeignKey(
                        name: "FK_Success_CollectionMeta_MetaId",
                        column: x => x.MetaId,
                        principalSchema: "Airports",
                        principalTable: "CollectionMeta",
                        principalColumn: "MetaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightOffers",
                schema: "Flights",
                columns: table => new
                {
                    FlightOffersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DictionariesId = table.Column<int>(nullable: true),
                    MetaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffers", x => x.FlightOffersId);
                    table.ForeignKey(
                        name: "FK_FlightOffers_Dictionaries_DictionariesId",
                        column: x => x.DictionariesId,
                        principalSchema: "Flights",
                        principalTable: "Dictionaries",
                        principalColumn: "DictionaryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightOffers_Meta_MetaId",
                        column: x => x.MetaId,
                        principalSchema: "Flights",
                        principalTable: "Meta",
                        principalColumn: "MetaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightStop",
                schema: "Flights",
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
                    table.PrimaryKey("PK_FlightStop", x => x.FlightStopId);
                    table.ForeignKey(
                        name: "FK_FlightStop_FlightSegment_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalSchema: "Flights",
                        principalTable: "FlightSegment",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FlightStop_AircraftEquipment_NewAircraftId",
                        column: x => x.NewAircraftId,
                        principalSchema: "Flights",
                        principalTable: "AircraftEquipment",
                        principalColumn: "AircraftEquipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Airports",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SuccessId = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    SelfId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    SubType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DetailedName = table.Column<string>(nullable: true),
                    TimeZoneOffset = table.Column<string>(nullable: true),
                    IataCode = table.Column<string>(nullable: true),
                    GeoCodeId = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    DistanceId = table.Column<int>(nullable: true),
                    AnalyticsId = table.Column<int>(nullable: true),
                    Relevance = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Airports",
                        principalTable: "Address",
                        principalColumn: "AdressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Analytics_AnalyticsId",
                        column: x => x.AnalyticsId,
                        principalSchema: "Airports",
                        principalTable: "Analytics",
                        principalColumn: "AnalyticsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Distance_DistanceId",
                        column: x => x.DistanceId,
                        principalSchema: "Airports",
                        principalTable: "Distance",
                        principalColumn: "DistanceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_GeoCode_GeoCodeId",
                        column: x => x.GeoCodeId,
                        principalSchema: "Airports",
                        principalTable: "GeoCode",
                        principalColumn: "GeoCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Self_SelfId",
                        column: x => x.SelfId,
                        principalSchema: "Airports",
                        principalTable: "Self",
                        principalColumn: "SelfId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Location_Success_SuccessId",
                        column: x => x.SuccessId,
                        principalSchema: "Airports",
                        principalTable: "Success",
                        principalColumn: "SuccessId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlightOffer",
                schema: "Flights",
                columns: table => new
                {
                    FlightOfferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightOffersId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightOffer", x => x.FlightOfferId);
                    table.ForeignKey(
                        name: "FK_FlightOffer_FlightOffers_FlightOffersId",
                        column: x => x.FlightOffersId,
                        principalSchema: "Flights",
                        principalTable: "FlightOffers",
                        principalColumn: "FlightOffersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                schema: "Flights",
                columns: table => new
                {
                    IssueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: true),
                    Code = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    FlightOffersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.IssueId);
                    table.ForeignKey(
                        name: "FK_Issue_FlightOffers_FlightOffersId",
                        column: x => x.FlightOffersId,
                        principalSchema: "Flights",
                        principalTable: "FlightOffers",
                        principalColumn: "FlightOffersId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Issue_IssueSource_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "Flights",
                        principalTable: "IssueSource",
                        principalColumn: "IssueSourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferItem",
                schema: "Flights",
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
                    table.PrimaryKey("PK_OfferItem", x => x.OfferItemId);
                    table.ForeignKey(
                        name: "FK_OfferItem_FlightOffer_FlightOfferId",
                        column: x => x.FlightOfferId,
                        principalSchema: "Flights",
                        principalTable: "FlightOffer",
                        principalColumn: "FlightOfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItem_Price_PriceId",
                        column: x => x.PriceId,
                        principalSchema: "Flights",
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItem_Price_PricePerAdultId",
                        column: x => x.PricePerAdultId,
                        principalSchema: "Flights",
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItem_Price_PricePerChildId",
                        column: x => x.PricePerChildId,
                        principalSchema: "Flights",
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItem_Price_PricePerInfantId",
                        column: x => x.PricePerInfantId,
                        principalSchema: "Flights",
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OfferItem_Price_PricePerSeniorId",
                        column: x => x.PricePerSeniorId,
                        principalSchema: "Flights",
                        principalTable: "Price",
                        principalColumn: "PriceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "Flights",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfferItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_OfferItem_OfferItemId",
                        column: x => x.OfferItemId,
                        principalSchema: "Flights",
                        principalTable: "OfferItem",
                        principalColumn: "OfferItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Segment",
                schema: "Flights",
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
                    table.PrimaryKey("PK_Segment", x => x.SegmentId);
                    table.ForeignKey(
                        name: "FK_Segment_FlightSegment_FlightSegmentId",
                        column: x => x.FlightSegmentId,
                        principalSchema: "Flights",
                        principalTable: "FlightSegment",
                        principalColumn: "FlightSegmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segment_PricingDetail_PricingDetailPerAdultId",
                        column: x => x.PricingDetailPerAdultId,
                        principalSchema: "Flights",
                        principalTable: "PricingDetail",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segment_PricingDetail_PricingDetailPerChildId",
                        column: x => x.PricingDetailPerChildId,
                        principalSchema: "Flights",
                        principalTable: "PricingDetail",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segment_PricingDetail_PricingDetailPerInfantId",
                        column: x => x.PricingDetailPerInfantId,
                        principalSchema: "Flights",
                        principalTable: "PricingDetail",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segment_PricingDetail_PricingDetailPerSeniorId",
                        column: x => x.PricingDetailPerSeniorId,
                        principalSchema: "Flights",
                        principalTable: "PricingDetail",
                        principalColumn: "PricingDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Flights",
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analytics_TravelersId",
                schema: "Airports",
                table: "Analytics",
                column: "TravelersId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionMeta_LinksId",
                schema: "Airports",
                table: "CollectionMeta",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AddressId",
                schema: "Airports",
                table: "Location",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AnalyticsId",
                schema: "Airports",
                table: "Location",
                column: "AnalyticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DistanceId",
                schema: "Airports",
                table: "Location",
                column: "DistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_GeoCodeId",
                schema: "Airports",
                table: "Location",
                column: "GeoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SelfId",
                schema: "Airports",
                table: "Location",
                column: "SelfId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SuccessId",
                schema: "Airports",
                table: "Location",
                column: "SuccessId");

            migrationBuilder.CreateIndex(
                name: "IX_Success_MetaId",
                schema: "Airports",
                table: "Success",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_AircraftId",
                schema: "Flights",
                table: "Dictionaries",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_CarriersId",
                schema: "Flights",
                table: "Dictionaries",
                column: "CarriersId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_CurrenciesId",
                schema: "Flights",
                table: "Dictionaries",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_LocationsId",
                schema: "Flights",
                table: "Dictionaries",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffer_FlightOffersId",
                schema: "Flights",
                table: "FlightOffer",
                column: "FlightOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_DictionariesId",
                schema: "Flights",
                table: "FlightOffers",
                column: "DictionariesId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightOffers_MetaId",
                schema: "Flights",
                table: "FlightOffers",
                column: "MetaId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegment_AircraftId",
                schema: "Flights",
                table: "FlightSegment",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegment_ArrivalId",
                schema: "Flights",
                table: "FlightSegment",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegment_DepartureId",
                schema: "Flights",
                table: "FlightSegment",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightSegment_OperatingId",
                schema: "Flights",
                table: "FlightSegment",
                column: "OperatingId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStop_FlightSegmentId",
                schema: "Flights",
                table: "FlightStop",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightStop_NewAircraftId",
                schema: "Flights",
                table: "FlightStop",
                column: "NewAircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_FlightOffersId",
                schema: "Flights",
                table: "Issue",
                column: "FlightOffersId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_SourceId",
                schema: "Flights",
                table: "Issue",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_DefaultsId",
                schema: "Flights",
                table: "Meta",
                column: "DefaultsId");

            migrationBuilder.CreateIndex(
                name: "IX_Meta_LinksId",
                schema: "Flights",
                table: "Meta",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_FlightOfferId",
                schema: "Flights",
                table: "OfferItem",
                column: "FlightOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PriceId",
                schema: "Flights",
                table: "OfferItem",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PricePerAdultId",
                schema: "Flights",
                table: "OfferItem",
                column: "PricePerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PricePerChildId",
                schema: "Flights",
                table: "OfferItem",
                column: "PricePerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PricePerInfantId",
                schema: "Flights",
                table: "OfferItem",
                column: "PricePerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferItem_PricePerSeniorId",
                schema: "Flights",
                table: "OfferItem",
                column: "PricePerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_FlightSegmentId",
                schema: "Flights",
                table: "Segment",
                column: "FlightSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_PricingDetailPerAdultId",
                schema: "Flights",
                table: "Segment",
                column: "PricingDetailPerAdultId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_PricingDetailPerChildId",
                schema: "Flights",
                table: "Segment",
                column: "PricingDetailPerChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_PricingDetailPerInfantId",
                schema: "Flights",
                table: "Segment",
                column: "PricingDetailPerInfantId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_PricingDetailPerSeniorId",
                schema: "Flights",
                table: "Segment",
                column: "PricingDetailPerSeniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_ServiceId",
                schema: "Flights",
                table: "Segment",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_OfferItemId",
                schema: "Flights",
                table: "Service",
                column: "OfferItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "FlightStop",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Issue",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Segment",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "Analytics",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "Distance",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "GeoCode",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "Self",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "Success",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "IssueSource",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "FlightSegment",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "PricingDetail",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Travelers",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "CollectionMeta",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "AircraftEquipment",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "FlightEndPoint",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "OperatingFlight",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "OfferItem",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "CollectionLinks",
                schema: "Airports");

            migrationBuilder.DropTable(
                name: "FlightOffer",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "FlightOffers",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Dictionaries",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Meta",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "DictionaryEntry",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "LocationEntry",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Defaults",
                schema: "Flights");

            migrationBuilder.DropTable(
                name: "Links",
                schema: "Flights");
        }
    }
}
