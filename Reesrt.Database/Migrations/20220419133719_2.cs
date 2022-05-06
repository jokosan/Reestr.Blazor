using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_Microdistrict_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.AlterColumn<int>(
                name: "MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_Microdistrict_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                column: "MicrodistrictId",
                principalTable: "Microdistrict",
                principalColumn: "IdMicrodistrict",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_Microdistrict_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.AlterColumn<int>(
                name: "MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_Microdistrict_MicrodistrictId",
                table: "RegisterOfEmergencyBuildings",
                column: "MicrodistrictId",
                principalTable: "Microdistrict",
                principalColumn: "IdMicrodistrict",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
