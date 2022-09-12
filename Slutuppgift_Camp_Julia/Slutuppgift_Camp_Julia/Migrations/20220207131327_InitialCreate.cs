using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slutuppgift_Camp_Julia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinID);
                });

            migrationBuilder.CreateTable(
                name: "Campers",
                columns: table => new
                {
                    CamperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campers", x => x.CamperID);
                });

            migrationBuilder.CreateTable(
                name: "Councelors",
                columns: table => new
                {
                    CouncelorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Councelors", x => x.CouncelorID);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKin",
                columns: table => new
                {
                    NextOfKinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKin", x => x.NextOfKinID);
                });

            migrationBuilder.CreateTable(
                name: "CamperStay",
                columns: table => new
                {
                    CamperStayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamperID = table.Column<int>(type: "int", nullable: false),
                    CabinID = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperStay", x => x.CamperStayID);
                    table.ForeignKey(
                        name: "FK_CamperStay_Cabins_CabinID",
                        column: x => x.CabinID,
                        principalTable: "Cabins",
                        principalColumn: "CabinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CamperStay_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "CamperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouncelorsStay",
                columns: table => new
                {
                    CouncelorStayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouncelorID = table.Column<int>(type: "int", nullable: false),
                    CabinID = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncelorsStay", x => x.CouncelorStayID);
                    table.ForeignKey(
                        name: "FK_CouncelorsStay_Cabins_CabinID",
                        column: x => x.CabinID,
                        principalTable: "Cabins",
                        principalColumn: "CabinID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouncelorsStay_Councelors_CouncelorID",
                        column: x => x.CouncelorID,
                        principalTable: "Councelors",
                        principalColumn: "CouncelorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKinVisit",
                columns: table => new
                {
                    NextOfKinVisitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CamperID = table.Column<int>(type: "int", nullable: false),
                    NextOfKinID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKinVisit", x => x.NextOfKinVisitID);
                    table.ForeignKey(
                        name: "FK_NextOfKinVisit_Campers_CamperID",
                        column: x => x.CamperID,
                        principalTable: "Campers",
                        principalColumn: "CamperID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NextOfKinVisit_NextOfKin_NextOfKinID",
                        column: x => x.NextOfKinID,
                        principalTable: "NextOfKin",
                        principalColumn: "NextOfKinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CamperStay_CabinID",
                table: "CamperStay",
                column: "CabinID");

            migrationBuilder.CreateIndex(
                name: "IX_CamperStay_CamperID",
                table: "CamperStay",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_CouncelorsStay_CabinID",
                table: "CouncelorsStay",
                column: "CabinID");

            migrationBuilder.CreateIndex(
                name: "IX_CouncelorsStay_CouncelorID",
                table: "CouncelorsStay",
                column: "CouncelorID");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKinVisit_CamperID",
                table: "NextOfKinVisit",
                column: "CamperID");

            migrationBuilder.CreateIndex(
                name: "IX_NextOfKinVisit_NextOfKinID",
                table: "NextOfKinVisit",
                column: "NextOfKinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperStay");

            migrationBuilder.DropTable(
                name: "CouncelorsStay");

            migrationBuilder.DropTable(
                name: "NextOfKinVisit");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Councelors");

            migrationBuilder.DropTable(
                name: "Campers");

            migrationBuilder.DropTable(
                name: "NextOfKin");
        }
    }
}
