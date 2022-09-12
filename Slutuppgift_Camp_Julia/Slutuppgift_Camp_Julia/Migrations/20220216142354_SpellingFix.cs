using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_Camp_Julia.Migrations
{
    public partial class SpellingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "NextOfKin",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "Councelors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "Campers",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "NextOfKin",
                newName: "FistName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Councelors",
                newName: "FistName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Campers",
                newName: "FistName");
        }
    }
}
