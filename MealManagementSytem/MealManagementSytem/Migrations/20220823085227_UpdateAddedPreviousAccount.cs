using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MealManagementSytem.Migrations
{
    public partial class UpdateAddedPreviousAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PreviousAccounts",
                columns: table => new
                {
                    PreviousAccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviousAccounts", x => x.PreviousAccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviousAccounts");

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
    }
}
