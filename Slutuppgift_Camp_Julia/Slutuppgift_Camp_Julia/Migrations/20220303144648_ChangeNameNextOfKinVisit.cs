using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_Camp_Julia.Migrations
{
    public partial class ChangeNameNextOfKinVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKinVisit_NextOfKin_NextOfKinID",
                table: "NextOfKinVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextOfKin",
                table: "NextOfKin");

            migrationBuilder.RenameTable(
                name: "NextOfKin",
                newName: "NextOfKins");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextOfKins",
                table: "NextOfKins",
                column: "NextOfKinID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKinVisit_NextOfKins_NextOfKinID",
                table: "NextOfKinVisit",
                column: "NextOfKinID",
                principalTable: "NextOfKins",
                principalColumn: "NextOfKinID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NextOfKinVisit_NextOfKins_NextOfKinID",
                table: "NextOfKinVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NextOfKins",
                table: "NextOfKins");

            migrationBuilder.RenameTable(
                name: "NextOfKins",
                newName: "NextOfKin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NextOfKin",
                table: "NextOfKin",
                column: "NextOfKinID");

            migrationBuilder.AddForeignKey(
                name: "FK_NextOfKinVisit_NextOfKin_NextOfKinID",
                table: "NextOfKinVisit",
                column: "NextOfKinID",
                principalTable: "NextOfKin",
                principalColumn: "NextOfKinID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
