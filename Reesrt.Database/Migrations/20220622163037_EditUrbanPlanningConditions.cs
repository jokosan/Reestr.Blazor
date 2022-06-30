using Microsoft.EntityFrameworkCore.Migrations;

namespace Reestr.Database.Migrations
{
    public partial class EditUrbanPlanningConditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_DocumentStatus_DocumentStatusId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_TypeOfConstruction_TypeOfConstructionId",
                table: "UrbanPlanningConditions");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UrbanPlanningConditions_DocumentStatus_DocumentStatusId",
                table: "UrbanPlanningConditions",
                column: "DocumentStatusId",
                principalTable: "DocumentStatus",
                principalColumn: "IdDocumentStatus",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UrbanPlanningConditions_TypeOfConstruction_TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                column: "TypeOfConstructionId",
                principalTable: "TypeOfConstruction",
                principalColumn: "IdTypeOfConstruction",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_DocumentStatus_DocumentStatusId",
                table: "UrbanPlanningConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_UrbanPlanningConditions_TypeOfConstruction_TypeOfConstructionId",
                table: "UrbanPlanningConditions");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfConstructionId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentStatusId",
                table: "UrbanPlanningConditions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
