using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class UpdatePassField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MemberPass",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MemberPass",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
