using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class EditTableUrbanPlanningConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UrbanPlanningConditions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UrbanPlanningConditions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChangesDescription",
                table: "UrbanPlanningConditions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationDescription",
                table: "UrbanPlanningConditions",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantName",
                table: "UrbanPlanningConditions",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addressing",
                table: "UrbanPlanningConditions",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatusId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentStatus",
                columns: table => new
                {
                    IdDocumentStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatus", x => x.IdDocumentStatus);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfConstruction",
                columns: table => new
                {
                    IdTypeOfConstruction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfConstruction", x => x.IdTypeOfConstruction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrbanPlanningConditions_DocumentStatusId",
                table: "UrbanPlanningConditions",
                column: "DocumentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UrbanPlanningConditions_TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                column: "TypeOfConstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrbanPlanningConditions_DocumentStatus_DocumentStatusId",
                table: "UrbanPlanningConditions",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "IdDocumentStatus",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrbanPlanningConditions_TypeOfConstruction_TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                column: "TypeOfConstructionId",
                principalTable: "TypeOfConstruction",
                principalColumn: "IdTypeOfConstruction",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_DocumentStatus_DocumentStatusId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_TypeOfConstruction_TypeOfConstructionId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropTable(
                name: "DocumentStatus");

            migrationBuilder.DropTable(
                name: "TypeOfConstruction");

            migrationBuilder.DropIndex(
                name: "IX_UrbanPlanningConditions_DocumentStatusId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropIndex(
                name: "IX_UrbanPlanningConditions_TypeOfConstructionId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropColumn(
                name: "Addressing",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropColumn(
                name: "DocumentStatusId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropColumn(
                name: "TypeOfConstructionId",
                table: "UrbanPlanningConditions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UrbanPlanningConditions",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChangesDescription",
                table: "UrbanPlanningConditions",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationDescription",
                table: "UrbanPlanningConditions",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantName",
                table: "UrbanPlanningConditions",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UrbanPlanningConditions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UrbanPlanningConditions",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true);
        }
    }
}
