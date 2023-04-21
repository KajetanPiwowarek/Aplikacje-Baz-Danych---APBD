using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmp_kolos_02.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssigmentDate" },
                values: new object[] { 1, 2, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFireTruck" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
