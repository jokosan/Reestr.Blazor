using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class CreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressingApi",
                columns: table => new
                {
                    IdApiBuildings = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAddressingApi = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    Longi = table.Column<decimal>(type: "decimal(18,10)", nullable: true),
                    NameUkr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postcode = table.Column<int>(type: "int", nullable: true),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SameAddrComm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Streetid = table.Column<int>(type: "int", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeUkr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Block = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DetailNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DetailUa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    DistrictUa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressingApi", x => x.IdApiBuildings);
                    table.UniqueConstraint("AK_AddressingApi_IdAddressingApi", x => x.IdAddressingApi);
                });

            migrationBuilder.CreateTable(
                name: "BuildingType",
                columns: table => new
                {
                    IdBuildingType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBuildingType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.IdBuildingType);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    IdDistricts = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDistricts = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.IdDistricts);
                });

            migrationBuilder.CreateTable(
                name: "InfoUser",
                columns: table => new
                {
                    IdInfoUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoUserId = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PlaceOfWork = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoUser", x => x.IdInfoUser);
                });

            migrationBuilder.CreateTable(
                name: "Microdistrict",
                columns: table => new
                {
                    IdMicrodistrict = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMicrodistrict = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microdistrict", x => x.IdMicrodistrict);
                });

            migrationBuilder.CreateTable(
                name: "PlotAssignments",
                columns: table => new
                {
                    IdPlotAssignment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotAssignments", x => x.IdPlotAssignment);
                });

            migrationBuilder.CreateTable(
                name: "PossibilityOfReconstruction",
                columns: table => new
                {
                    IdPossibilityOfReconstruction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ScanDoc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibilityOfReconstruction", x => x.IdPossibilityOfReconstruction);
                });

            migrationBuilder.CreateTable(
                name: "Solutions",
                columns: table => new
                {
                    IdSolution = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DecisionNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DecisionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UrlSolution = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solutions", x => x.IdSolution);
                });

            migrationBuilder.CreateTable(
                name: "StreetCategories",
                columns: table => new
                {
                    IdStreetCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategoryRu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NameCategoryUa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullNameCategoryRu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FullNameCategoryUa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetCategories", x => x.IdStreetCategory);
                });

            migrationBuilder.CreateTable(
                name: "targetLands",
                columns: table => new
                {
                    IdTargetLand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_targetLands", x => x.IdTargetLand);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfOwnership",
                columns: table => new
                {
                    IdTypeOfOwnership = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTypeOfOwnership = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfOwnership", x => x.IdTypeOfOwnership);
                });

            migrationBuilder.CreateTable(
                name: "ProjectArchives",
                columns: table => new
                {
                    IdProjectArchive = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: true),
                    ProjectNumber = table.Column<int>(type: "int", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ProjectOrganization = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AddressingId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VarianceApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectArchives", x => x.IdProjectArchive);
                    table.ForeignKey(
                        name: "FK_ProjectArchives_AddressingApi_AddressingId",
                        column: x => x.AddressingId,
                        principalTable: "AddressingApi",
                        principalColumn: "IdApiBuildings",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    IdLand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadastralNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TargetLandId = table.Column<int>(type: "int", nullable: true),
                    PlotAssignmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.IdLand);
                    table.ForeignKey(
                        name: "FK_Lands_PlotAssignments_PlotAssignmentId",
                        column: x => x.PlotAssignmentId,
                        principalTable: "PlotAssignments",
                        principalColumn: "IdPlotAssignment",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lands_targetLands_TargetLandId",
                        column: x => x.TargetLandId,
                        principalTable: "targetLands",
                        principalColumn: "IdTargetLand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterOfEmergencyBuildings",
                columns: table => new
                {
                    IdRegisterOfEmergencyBuildings = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MicrodistrictId = table.Column<int>(type: "int", nullable: true),
                    SectorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    TypeOfOwnershipId = table.Column<int>(type: "int", nullable: true),
                    TypeOfDestruction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeBuildings = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PhotographicFixationId = table.Column<int>(type: "int", nullable: true),
                    PossibilityOfReconstructionId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    UserNameInsert = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateInsert = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserNameUpdate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressesApiId = table.Column<int>(type: "int", nullable: true),
                    DataSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterOfEmergencyBuildings", x => x.IdRegisterOfEmergencyBuildings);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_AddressingApi_AddressesApiId",
                        column: x => x.AddressesApiId,
                        principalTable: "AddressingApi",
                        principalColumn: "IdAddressingApi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_BuildingType_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingType",
                        principalColumn: "IdBuildingType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_Microdistrict_MicrodistrictId",
                        column: x => x.MicrodistrictId,
                        principalTable: "Microdistrict",
                        principalColumn: "IdMicrodistrict",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_PossibilityOfReconstruction_PossibilityOfReconstructionId",
                        column: x => x.PossibilityOfReconstructionId,
                        principalTable: "PossibilityOfReconstruction",
                        principalColumn: "IdPossibilityOfReconstruction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_TypeOfOwnership_TypeOfOwnershipId",
                        column: x => x.TypeOfOwnershipId,
                        principalTable: "TypeOfOwnership",
                        principalColumn: "IdTypeOfOwnership",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionPassports",
                columns: table => new
                {
                    IdConstructionPassport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorityName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ApplicantName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ApplicantIdentifier = table.Column<int>(type: "int", nullable: true),
                    AuthoritytIdentifier = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    LandId = table.Column<int>(type: "int", nullable: true),
                    AddressingId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangesDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    CancellationDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionPassports", x => x.IdConstructionPassport);
                    table.ForeignKey(
                        name: "FK_ConstructionPassports_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "IdLand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrbanPlanningConditions",
                columns: table => new
                {
                    IdUrbanPlanningConditions = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    OrderIssued = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorityName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ApplicantName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    ApplicantIdentifier = table.Column<int>(type: "int", nullable: true),
                    AuthoritytIdentifier = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    LandId = table.Column<int>(type: "int", nullable: true),
                    AddressingId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangesDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    CancellationDescription = table.Column<string>(type: "nvarchar(550)", maxLength: 550, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrbanPlanningConditions", x => x.IdUrbanPlanningConditions);
                    table.ForeignKey(
                        name: "FK_UrbanPlanningConditions_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "IdLand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotographicFixations",
                columns: table => new
                {
                    IdPhotographicFixation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterOfEmergencyBuildingsId = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographicFixations", x => x.IdPhotographicFixation);
                    table.ForeignKey(
                        name: "FK_PhotographicFixations_RegisterOfEmergencyBuildings_RegisterOfEmergencyBuildingsId",
                        column: x => x.RegisterOfEmergencyBuildingsId,
                        principalTable: "RegisterOfEmergencyBuildings",
                        principalColumn: "IdRegisterOfEmergencyBuildings",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionPassports_LandId",
                table: "ConstructionPassports",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_PlotAssignmentId",
                table: "Lands",
                column: "PlotAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_TargetLandId",
                table: "Lands",
                column: "TargetLandId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographicFixations_RegisterOfEmergencyBuildingsId",
                table: "PhotographicFixations",
                column: "RegisterOfEmergencyBuildingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectArchives_AddressingId",
                table: "ProjectArchives",
                column: "AddressingId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_AddressesApiId",
                table: "RegisterOfEmergencyBuildings",
                column: "AddressesApiId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_BuildingTypeId",
                table: "RegisterOfEmergencyBuildings",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                column: "MicrodistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_PossibilityOfReconstructionId",
                table: "RegisterOfEmergencyBuildings",
                column: "PossibilityOfReconstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_TypeOfOwnershipId",
                table: "RegisterOfEmergencyBuildings",
                column: "TypeOfOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_UrbanPlanningConditions_LandId",
                table: "UrbanPlanningConditions",
                column: "LandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstructionPassports");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "InfoUser");

            migrationBuilder.DropTable(
                name: "PhotographicFixations");

            migrationBuilder.DropTable(
                name: "ProjectArchives");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "StreetCategories");

            migrationBuilder.DropTable(
                name: "UrbanPlanningConditions");

            migrationBuilder.DropTable(
                name: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "AddressingApi");

            migrationBuilder.DropTable(
                name: "BuildingType");

            migrationBuilder.DropTable(
                name: "Microdistrict");

            migrationBuilder.DropTable(
                name: "PossibilityOfReconstruction");

            migrationBuilder.DropTable(
                name: "TypeOfOwnership");

            migrationBuilder.DropTable(
                name: "PlotAssignments");

            migrationBuilder.DropTable(
                name: "targetLands");
        }
    }
}
