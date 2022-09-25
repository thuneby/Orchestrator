using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parse.Migrations
{
    public partial class OsInfoBs601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bs601Start",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DataSupplierCvr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SubSystem = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DeliveryType = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DeliveryId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Filler01 = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: true),
                    DeliveryCreationDate = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(73)", maxLength: 73, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs601Start", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OsInfoStart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    KONSTANT = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SYSTEMTEKST = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    IDENTIFIKATION = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DATALEVERANDORNUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    LEVERANCEKVITTERING = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsInfoStart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bs601End",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberOfRecord5262 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Filler01 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberOfRecord22 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    DeliveryStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DataSupplierCvr = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SubSystem = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DeliveryType = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    NumberOfSections = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NumberOfRecord42 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs601End", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bs601End_Bs601Start_DeliveryStartId",
                        column: x => x.DeliveryStartId,
                        principalTable: "Bs601Start",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bs601SectionStart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DataSupplierId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DeliveryCreationDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Filler03 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Filler04 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MainTextLine = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    DeliveryStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SectionNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs601SectionStart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bs601SectionStart_Bs601Start_DeliveryStartId",
                        column: x => x.DeliveryStartId,
                        principalTable: "Bs601Start",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsInfoEnd",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    KONSTANT = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    TOTALANTAL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TOTALBELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DATALEVERANDORNUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    OsStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsInfoEnd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsInfoEnd_OsInfoStart_OsStartId",
                        column: x => x.OsStartId,
                        principalTable: "OsInfoStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsSectionStart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSART = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DISPOSITIONSDATO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    REGISTRERINGSNUMMER = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    KONTONUMMER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DATALEVERANDORNUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CVRNUMMERAFSENDER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PBSNUMMERMODTAGER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    OsStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsSectionStart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsSectionStart_OsInfoStart_OsStartId",
                        column: x => x.OsStartId,
                        principalTable: "OsInfoStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bs601SectionEnd",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    NumberOfRecord42 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    TotalAmount = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberOfRecord5262 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Filler03 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumberOfRecord22 = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Filler04 = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    SectionStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SectionNumber = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bs601SectionEnd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bs601SectionEnd_Bs601SectionStart_SectionStartId",
                        column: x => x.SectionStartId,
                        principalTable: "Bs601SectionStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord42",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MandateNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    PaymentDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SignCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Filler01 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PayerId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SectionStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord42", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord42_Bs601SectionStart_SectionStartId",
                        column: x => x.SectionStartId,
                        principalTable: "Bs601SectionStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord00",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANTAL_INFO_RECORDS = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PBSNUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AFDELINGSNUMMER = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    AFTALENUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CPR_NUMMER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    KUNDENUMMER_AFSENDER = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    KUNDENUMMER_MODTAGER = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    INDBETALT_BELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FORTEGN = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PERIODE_FRA = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PERIODE_TIL = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    OVERENSKOMSTNUMMER = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SPECIFICERET_BELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    OsSectionStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord00", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord00_OsSectionStart_OsSectionStartId",
                        column: x => x.OsSectionStartId,
                        principalTable: "OsSectionStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsSectionEnd",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ANTAL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DISPOSITIONSDATO = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    AFSENDERREGISTRERINGSNUMMER = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    AFSENDERKONTONUMMER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DATALEVERANDORNUMMER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    CVRNUMMERAFSENDER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PBSNUMMERMODTAGER = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    OsSectionStartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsSectionEnd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsSectionEnd_OsSectionStart_OsSectionStartId",
                        column: x => x.OsSectionStartId,
                        principalTable: "OsSectionStart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord22",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(42)", maxLength: 42, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BsRecord42Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord22", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord22_BsRecord42_BsRecord42Id",
                        column: x => x.BsRecord42Id,
                        principalTable: "BsRecord42",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord2209",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Postcode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Filler03 = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BsRecord42Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord2209", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord2209_BsRecord42_BsRecord42Id",
                        column: x => x.BsRecord42Id,
                        principalTable: "BsRecord42",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord2210",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DebtorCvrCpr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DispatchSpeed = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MandatoryPrint = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BsRecord42Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord2210", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord2210_BsRecord42_BsRecord42Id",
                        column: x => x.BsRecord42Id,
                        principalTable: "BsRecord42",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord52",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MandateNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Filler01 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    TextLine = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BsRecord42Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord52", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord52_BsRecord42_BsRecord42Id",
                        column: x => x.BsRecord42Id,
                        principalTable: "BsRecord42",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BsRecord62",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Filler01 = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    Filler02 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    TextLine = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Filler03 = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    DataRecordType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PbsNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TransactionCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    DataRecordNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DebtorGroupNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CustomerNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    BsRecord42Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BsRecord62", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BsRecord62_BsRecord42_BsRecord42Id",
                        column: x => x.BsRecord42Id,
                        principalTable: "BsRecord42",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord01",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STARTDATO_KUNDE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    KUNDENAVN = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    OPLYSNINGSKODE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    PENSIONSALDERKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    PENSIONSALDER = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    STARTDATO_AFLONNINGSFORM = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AFLONNINGSFORM = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    ANCIENNITET_FRA_DATO = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FRATRAEDELSESDATO = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    RESERVETEKST = table.Column<string>(type: "nvarchar(37)", maxLength: 37, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord01", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord01_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord02",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STARTDATO_PENSIONSGIVENDE_LON = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PENSIONSGIVENDE_LON = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    STARTDATO_PENSIONSTYPE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PENSIONSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    STARTDATO_NORMALBIDRAG = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    NORMALBIDRAG = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    ARBEJDSGIVERS_ANDEL_AF_NORMALBIDRAG = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    STARTDATO_PENSIONSBIDRAGSPROCENT = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PENSIONSBIDRAGSPROCENT = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    ARBEJDSGIVER_PENSIONSBIDRAGSPROCENT = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    STARTDATO_LONTRIN = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    LONTRIN = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    STARTDATO_GRUPPELIVSANDEL = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    GRUPPELIVSANDEL_AF_INDBETALT_BELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord02", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord02_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord03",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    STARTDATO_AFVIGELSE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AFVIGELSESKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AFVIGELSESBELOB = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FORTEGN = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    AFVIGELSESPROCENT = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    STARTDATO_BESKAEFTIGELSESGRAD = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    BESKAEFTIGELSESGRAD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BESKAEFTIGELSESGRAD_TAELLER = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    BESKAEFTIGELSESGRAD_NAEVNER = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    RESERVETEKST = table.Column<string>(type: "nvarchar(58)", maxLength: 58, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord03", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord03_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord04",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    REGULERINGSKODE1 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    REGULERINGSBELOB1 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FORTEGN1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    STARTDATO_REGULERING1 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SLUTDATO_REGULERING1 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    REGULERINGSKODE2 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    REGULERINGSBELOB2 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FORTEGN2 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    STARTDATO_REGULERING2 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SLUTDATO_REGULERING2 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    REGULERINGSKODE3 = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    REGULERINGSBELOB3 = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    FORTEGN3 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    STARTDATO_REGULERING3 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    SLUTDATO_REGULERING3 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FILLER = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord04", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord04_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord05",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ADRESSE1 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    ADRESSE2 = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    BYNAVN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    POSTNUMMER = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TAL1 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TAL2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RESERVETEKST = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord05", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord05_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OsRecord10",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RESERVE1KODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RESERVE1 = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    RESERVE2KODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RESERVE2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RESERVE3KODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RESERVE3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RESERVE4KODE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    RESERVE4 = table.Column<string>(type: "nvarchar(61)", maxLength: 61, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantÍd = table.Column<long>(type: "bigint", nullable: false),
                    SYSTEMKODE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RECORDTYPE = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    OVERFORSELSTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    INFOTYPE = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    INFORECORDTYPE = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SEKVENSNUMMER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    OsRecord00Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsRecord10", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OsRecord10_OsRecord00_OsRecord00Id",
                        column: x => x.OsRecord00Id,
                        principalTable: "OsRecord00",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bs601End_DeliveryStartId",
                table: "Bs601End",
                column: "DeliveryStartId");

            migrationBuilder.CreateIndex(
                name: "IX_Bs601SectionEnd_SectionStartId",
                table: "Bs601SectionEnd",
                column: "SectionStartId");

            migrationBuilder.CreateIndex(
                name: "IX_Bs601SectionStart_DeliveryStartId",
                table: "Bs601SectionStart",
                column: "DeliveryStartId");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord22_BsRecord42Id",
                table: "BsRecord22",
                column: "BsRecord42Id");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord2209_BsRecord42Id",
                table: "BsRecord2209",
                column: "BsRecord42Id",
                unique: true,
                filter: "[BsRecord42Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord2210_BsRecord42Id",
                table: "BsRecord2210",
                column: "BsRecord42Id",
                unique: true,
                filter: "[BsRecord42Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord42_SectionStartId",
                table: "BsRecord42",
                column: "SectionStartId");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord52_BsRecord42Id",
                table: "BsRecord52",
                column: "BsRecord42Id");

            migrationBuilder.CreateIndex(
                name: "IX_BsRecord62_BsRecord42Id",
                table: "BsRecord62",
                column: "BsRecord42Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsInfoEnd_OsStartId",
                table: "OsInfoEnd",
                column: "OsStartId");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord00_OsSectionStartId",
                table: "OsRecord00",
                column: "OsSectionStartId");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord01_OsRecord00Id",
                table: "OsRecord01",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord02_OsRecord00Id",
                table: "OsRecord02",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord03_OsRecord00Id",
                table: "OsRecord03",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord04_OsRecord00Id",
                table: "OsRecord04",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord05_OsRecord00Id",
                table: "OsRecord05",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsRecord10_OsRecord00Id",
                table: "OsRecord10",
                column: "OsRecord00Id");

            migrationBuilder.CreateIndex(
                name: "IX_OsSectionEnd_OsSectionStartId",
                table: "OsSectionEnd",
                column: "OsSectionStartId");

            migrationBuilder.CreateIndex(
                name: "IX_OsSectionStart_OsStartId",
                table: "OsSectionStart",
                column: "OsStartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bs601End");

            migrationBuilder.DropTable(
                name: "Bs601SectionEnd");

            migrationBuilder.DropTable(
                name: "BsRecord22");

            migrationBuilder.DropTable(
                name: "BsRecord2209");

            migrationBuilder.DropTable(
                name: "BsRecord2210");

            migrationBuilder.DropTable(
                name: "BsRecord52");

            migrationBuilder.DropTable(
                name: "BsRecord62");

            migrationBuilder.DropTable(
                name: "OsInfoEnd");

            migrationBuilder.DropTable(
                name: "OsRecord01");

            migrationBuilder.DropTable(
                name: "OsRecord02");

            migrationBuilder.DropTable(
                name: "OsRecord03");

            migrationBuilder.DropTable(
                name: "OsRecord04");

            migrationBuilder.DropTable(
                name: "OsRecord05");

            migrationBuilder.DropTable(
                name: "OsRecord10");

            migrationBuilder.DropTable(
                name: "OsSectionEnd");

            migrationBuilder.DropTable(
                name: "BsRecord42");

            migrationBuilder.DropTable(
                name: "OsRecord00");

            migrationBuilder.DropTable(
                name: "Bs601SectionStart");

            migrationBuilder.DropTable(
                name: "OsSectionStart");

            migrationBuilder.DropTable(
                name: "Bs601Start");

            migrationBuilder.DropTable(
                name: "OsInfoStart");
        }
    }
}
