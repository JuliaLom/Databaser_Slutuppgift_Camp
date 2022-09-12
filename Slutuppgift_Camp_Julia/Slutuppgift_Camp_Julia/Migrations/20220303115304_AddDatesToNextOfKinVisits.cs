using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_Camp_Julia.Migrations
{
    public partial class AddDatesToNextOfKinVisits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "NextOfKinVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "NextOfKinVisit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "NextOfKinVisit");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "NextOfKinVisit");
        }
    }
}
