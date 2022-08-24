using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class AddedPreviousAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousAmount",
                table: "Deposites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PreviousAmount",
                table: "Deposites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
