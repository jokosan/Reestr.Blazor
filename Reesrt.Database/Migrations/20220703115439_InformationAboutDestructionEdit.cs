using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class InformationAboutDestructionEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterOfEmergencyBuildings_InformationAboutDestruction_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropIndex(
                name: "IX_RegisterOfEmergencyBuildings_InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropColumn(
                name: "InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.AddColumn<int>(
                name: "RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "InformationAboutDestruction",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutDestruction_RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction",
                column: "RegisterOfEmergencyBuildingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformationAboutDestruction_RegisterOfEmergencyBuildings_RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction",
                column: "RegisterOfEmergencyBuildingsId",
                principalTable: "RegisterOfEmergencyBuildings",
                principalColumn: "IdRegisterOfEmergencyBuildings",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformationAboutDestruction_RegisterOfEmergencyBuildings_RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction");

            migrationBuilder.DropIndex(
                name: "IX_InformationAboutDestruction_RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction");

            migrationBuilder.DropColumn(
                name: "RegisterOfEmergencyBuildingsId",
                table: "InformationAboutDestruction");

            migrationBuilder.DropColumn(
                name: "date",
                table: "InformationAboutDestruction");

            migrationBuilder.AddColumn<int>(
                name: "InformationAboutDestructionId",
                table: "RegisterOfEmergencyBuildings",
                type: "int",
                nullable: true);

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
    }
}
