using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class AddedGuestLunchDinner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestDinner",
                table: "Details",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuestLunch",
                table: "Details",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestDinner",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "GuestLunch",
                table: "Details");
        }
    }
}
