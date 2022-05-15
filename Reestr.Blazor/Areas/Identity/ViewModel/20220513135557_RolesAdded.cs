using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Blazor.Areas.Identity.ViewModel
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4c4514a-7050-4832-bae2-4ad86786f7c3", "94a9ebd2-4f83-4d40-aa6a-6d29e724f7e8", "SuperUser", "SUOERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "331b24a2-4647-477b-a068-f0c72bbad4f0", "e5011994-5783-4a9e-8d02-15e5562f02e3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331b24a2-4647-477b-a068-f0c72bbad4f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4c4514a-7050-4832-bae2-4ad86786f7c3");
        }
    }
}
