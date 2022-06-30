using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class InformationAboutDestruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformationAboutDestruction",
                columns: table => new
                {
                    IdInformationAboutDestruction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisterOfEmergencyBuildingsId = table.Column<int>(type: "int", nullable: false),
                    BuildingStructures = table.Column<bool>(type: "bit", nullable: false),
                    CompleteDestructionOfTheBuilding = table.Column<bool>(type: "bit", nullable: false),
                    DamageDesign = table.Column<bool>(type: "bit", nullable: false),
                    DestroyedBasement = table.Column<bool>(type: "bit", nullable: false),
                    RoofDestruction = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<bool>(type: "bit", nullable: false),
                    GlazingDamage = table.Column<bool>(type: "bit", nullable: false),
                    GlazingDamageQuantity = table.Column<int>(type: "int", nullable: true),
                    BalconiesDestroyed = table.Column<bool>(type: "bit", nullable: false),
                    BalconiesDestroyedQuantity = table.Column<int>(type: "int", nullable: true),
                    DestroyedEntrances = table.Column<bool>(type: "bit", nullable: false),
                    DamagedElevators = table.Column<bool>(type: "bit", nullable: false),
                    Electricity = table.Column<bool>(type: "bit", nullable: false),
                    Gas = table.Column<bool>(type: "bit", nullable: false),
                    ColdWater = table.Column<bool>(type: "bit", nullable: false),
                    HotWater = table.Column<bool>(type: "bit", nullable: false),
                    Heating = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutDestruction", x => x.IdInformationAboutDestruction);
                    table.ForeignKey(
                        name: "FK_InformationAboutDestruction_RegisterOfEmergencyBuildings_RegisterOfEmergencyBuildingsId",
                        column: x => x.RegisterOfEmergencyBuildingsId,
                        principalTable: "RegisterOfEmergencyBuildings",
                        principalColumn: "IdRegisterOfEmergencyBuildings",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutDestruction_RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction",
                column: "RegisterOfEmergencyBuildingsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationAboutDestruction");
        }
    }
}
