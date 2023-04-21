using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmp_kolos_02.Migrations
{
    public partial class AddedCFTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeedSpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruck_pk", x => x.IdFireTruck);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Action",
                columns: table => new
                {
                    IdFireTruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    AssigmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruckAction_pk", x => new { x.IdFireTruck, x.IdAction });
                    table.ForeignKey(
                        name: "FireTruckAction_Action",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FireTruckAction_FireTruck",
                        column: x => x.IdFireTruck,
                        principalTable: "FireTruck",
                        principalColumn: "IdFireTruck",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdAction",
                table: "FireTruck_Action",
                column: "IdAction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireTruck_Action");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireTruck");
        }
    }
}
