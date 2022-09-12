using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_Camp_Julia.Migrations
{
    public partial class SpellingFixCouncelorStay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorsStay_Cabins_CabinID",
                table: "CouncelorsStay");

            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorsStay_Councelors_CouncelorID",
                table: "CouncelorsStay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CouncelorsStay",
                table: "CouncelorsStay");

            migrationBuilder.RenameTable(
                name: "CouncelorsStay",
                newName: "CouncelorStay");

            migrationBuilder.RenameIndex(
                name: "IX_CouncelorsStay_CouncelorID",
                table: "CouncelorStay",
                newName: "IX_CouncelorStay_CouncelorID");

            migrationBuilder.RenameIndex(
                name: "IX_CouncelorsStay_CabinID",
                table: "CouncelorStay",
                newName: "IX_CouncelorStay_CabinID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CouncelorStay",
                table: "CouncelorStay",
                column: "CouncelorStayID");

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorStay_Cabins_CabinID",
                table: "CouncelorStay",
                column: "CabinID",
                principalTable: "Cabins",
                principalColumn: "CabinID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorStay_Councelors_CouncelorID",
                table: "CouncelorStay",
                column: "CouncelorID",
                principalTable: "Councelors",
                principalColumn: "CouncelorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorStay_Cabins_CabinID",
                table: "CouncelorStay");

            migrationBuilder.DropForeignKey(
                name: "FK_CouncelorStay_Councelors_CouncelorID",
                table: "CouncelorStay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CouncelorStay",
                table: "CouncelorStay");

            migrationBuilder.RenameTable(
                name: "CouncelorStay",
                newName: "CouncelorsStay");

            migrationBuilder.RenameIndex(
                name: "IX_CouncelorStay_CouncelorID",
                table: "CouncelorsStay",
                newName: "IX_CouncelorsStay_CouncelorID");

            migrationBuilder.RenameIndex(
                name: "IX_CouncelorStay_CabinID",
                table: "CouncelorsStay",
                newName: "IX_CouncelorsStay_CabinID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CouncelorsStay",
                table: "CouncelorsStay",
                column: "CouncelorStayID");

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorsStay_Cabins_CabinID",
                table: "CouncelorsStay",
                column: "CabinID",
                principalTable: "Cabins",
                principalColumn: "CabinID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CouncelorsStay_Councelors_CouncelorID",
                table: "CouncelorsStay",
                column: "CouncelorID",
                principalTable: "Councelors",
                principalColumn: "CouncelorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
