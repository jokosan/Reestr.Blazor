using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class eInformationAboutDestruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InformationAboutDestruction",
                columns: table => new
                {
                    IdInformationAboutDestruction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOfEmergencyBuildings_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings",
                column: "InformationAboutDestructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_InformationAboutDestruction_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings",
                column: "InformationAboutDestructionId",
                principalTable: "InformationAboutDestruction",
                principalColumn: "IdInformationAboutDestruction",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_InformationAboutDestruction_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropTable(
                name: "InformationAboutDestruction");

            migrationBuilder.DropIndex(
                name: "IX_RegisterOfEmergencyBuildings_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropColumn(
                name: "InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");
        }
    }
}
