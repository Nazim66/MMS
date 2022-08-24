using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class UpdateAddedPreviousAccountDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Others",
                table: "Others");

            migrationBuilder.RenameTable(
                name: "Others",
                newName: "Other");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Other",
                table: "Other",
                column: "OtherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Other",
                table: "Other");

            migrationBuilder.RenameTable(
                name: "Other",
                newName: "Others");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Others",
                table: "Others",
                column: "OtherId");
        }
    }
}
