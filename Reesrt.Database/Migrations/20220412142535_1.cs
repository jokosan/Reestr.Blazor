using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    IdAddressType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAddressType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.IdAddressType);
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
                name: "PhotographicFixation",
                columns: table => new
                {
                    IdPhotographicFixation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographicFixation", x => x.IdPhotographicFixation);
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
                name: "Postcodes",
                columns: table => new
                {
                    IdPostcode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Csode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.IdPostcode);
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
                name: "Streets",
                columns: table => new
                {
                    IdStreets = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetCategoryId = table.Column<int>(type: "int", nullable: true),
                    SolutionId = table.Column<int>(type: "int", nullable: true),
                    StreetsMapId = table.Column<int>(type: "int", nullable: true),
                    NameStreetsRu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameStreetsUa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.IdStreets);
                    table.ForeignKey(
                        name: "FK_Streets_Solutions_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solutions",
                        principalColumn: "IdSolution",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Streets_StreetCategories_StreetCategoryId",
                        column: x => x.StreetCategoryId,
                        principalTable: "StreetCategories",
                        principalColumn: "IdStreetCategory",
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
                name: "Addressings",
                columns: table => new
                {
                    IdAddressing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetsId = table.Column<int>(type: "int", nullable: true),
                    DistrictsId = table.Column<int>(type: "int", nullable: true),
                    AddressingMapId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Frame = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    Letter = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PostcodeId = table.Column<int>(type: "int", nullable: true),
                    AddressTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addressings", x => x.IdAddressing);
                    table.ForeignKey(
                        name: "FK_Addressings_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "IdAddressType",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addressings_Districts_DistrictsId",
                        column: x => x.DistrictsId,
                        principalTable: "Districts",
                        principalColumn: "IdDistricts",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addressings_Postcodes_PostcodeId",
                        column: x => x.PostcodeId,
                        principalTable: "Postcodes",
                        principalColumn: "IdPostcode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addressings_Streets_StreetsId",
                        column: x => x.StreetsId,
                        principalTable: "Streets",
                        principalColumn: "IdStreets",
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
                        name: "FK_ConstructionPassports_Addressings_AddressingId",
                        column: x => x.AddressingId,
                        principalTable: "Addressings",
                        principalColumn: "IdAddressing",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConstructionPassports_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "IdLand",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ProjectArchives_Addressings_AddressingId",
                        column: x => x.AddressingId,
                        principalTable: "Addressings",
                        principalColumn: "IdAddressing",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterOfEmergencyBuildings",
                columns: table => new
                {
                    IdRegisterOfEmergencyBuildings = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MicrodistrictId = table.Column<int>(type: "int", nullable: false),
                    SectorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingTypeId = table.Column<int>(type: "int", nullable: true),
                    TypeOfOwnershipId = table.Column<int>(type: "int", nullable: true),
                    AddressingId = table.Column<int>(type: "int", nullable: true),
                    TypeOfDestruction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeBuildings = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PhotographicFixationId = table.Column<int>(type: "int", nullable: true),
                    PossibilityOfReconstructionId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterOfEmergencyBuildings", x => x.IdRegisterOfEmergencyBuildings);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_Addressings_AddressingId",
                        column: x => x.AddressingId,
                        principalTable: "Addressings",
                        principalColumn: "IdAddressing",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterOfEmergencyBuildings_PhotographicFixation_PhotographicFixationId",
                        column: x => x.PhotographicFixationId,
                        principalTable: "PhotographicFixation",
                        principalColumn: "IdPhotographicFixation",
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
                        name: "FK_UrbanPlanningConditions_Addressings_AddressingId",
                        column: x => x.AddressingId,
                        principalTable: "Addressings",
                        principalColumn: "IdAddressing",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UrbanPlanningConditions_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "IdLand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addressings_AddressTypeId",
                table: "Addressings",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addressings_DistrictsId",
                table: "Addressings",
                column: "DistrictsId");

            migrationBuilder.CreateIndex(
                name: "IX_Addressings_PostcodeId",
                table: "Addressings",
                column: "PostcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addressings_StreetsId",
                table: "Addressings",
                column: "StreetsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionPassports_AddressingId",
                table: "ConstructionPassports",
                column: "AddressingId");

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
                name: "IX_ProjectArchives_AddressingId",
                table: "ProjectArchives",
                column: "AddressingId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_AddressingId",
                table: "RegisterOfEmergencyBuildings",
                column: "AddressingId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_BuildingTypeId",
                table: "RegisterOfEmergencyBuildings",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                column: "MicrodistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_PhotographicFixationId",
                table: "RegisterOfEmergencyBuildings",
                column: "PhotographicFixationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_PossibilityOfReconstructionId",
                table: "RegisterOfEmergencyBuildings",
                column: "PossibilityOfReconstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_TypeOfOwnershipId",
                table: "RegisterOfEmergencyBuildings",
                column: "TypeOfOwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_SolutionId",
                table: "Streets",
                column: "SolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Streets_StreetCategoryId",
                table: "Streets",
                column: "StreetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UrbanPlanningConditions_AddressingId",
                table: "UrbanPlanningConditions",
                column: "AddressingId");

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
                name: "ProjectArchives");

            migrationBuilder.DropTable(
                name: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropTable(
                name: "UrbanPlanningConditions");

            migrationBuilder.DropTable(
                name: "BuildingType");

            migrationBuilder.DropTable(
                name: "Microdistrict");

            migrationBuilder.DropTable(
                name: "PhotographicFixation");

            migrationBuilder.DropTable(
                name: "PossibilityOfReconstruction");

            migrationBuilder.DropTable(
                name: "TypeOfOwnership");

            migrationBuilder.DropTable(
                name: "Addressings");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Postcodes");

            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "PlotAssignments");

            migrationBuilder.DropTable(
                name: "targetLands");

            migrationBuilder.DropTable(
                name: "Solutions");

            migrationBuilder.DropTable(
                name: "StreetCategories");
        }
    }
}
