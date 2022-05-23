using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class NewСolumnTableRegisterOfEmergencyBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInsert",
                table: "RegisterOfEmergencyBuildings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "RegisterOfEmergencyBuildings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameInsert",
                table: "RegisterOfEmergencyBuildings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameUpdate",
                table: "RegisterOfEmergencyBuildings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateInsert",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropColumn(
                name: "UserNameInsert",
                table: "RegisterOfEmergencyBuildings");

            migrationBuilder.DropColumn(
                name: "UserNameUpdate",
                table: "RegisterOfEmergencyBuildings");
        }
    }
}
