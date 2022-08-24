using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class UpdateDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Detailss",
                table: "Detailss");

            migrationBuilder.RenameTable(
                name: "Detailss",
                newName: "Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "Detailss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Detailss",
                table: "Detailss",
                column: "MealId");
        }
    }
}
