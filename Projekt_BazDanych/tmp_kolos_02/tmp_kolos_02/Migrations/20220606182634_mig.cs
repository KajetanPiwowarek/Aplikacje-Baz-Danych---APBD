using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tmp_kolos_02.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "SpecialEquipment",
                table: "FireTruck",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "NeedSpecialEquipment",
                table: "Action",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2012, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2014, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2013, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2015, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2014, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFireTruck", "OperationNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "2137", true },
                    { 2, "69420", true },
                    { 3, "42069", false }
                });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssigmentDate" },
                values: new object[] { 3, 1, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssigmentDate" },
                values: new object[] { 2, 2, new DateTime(2018, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFireTruck", "AssigmentDate" },
                values: new object[] { 1, 3, new DateTime(2018, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFireTruck" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFireTruck" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFireTruck" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FireTruck",
                keyColumn: "IdFireTruck",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FireTruck",
                keyColumn: "IdFireTruck",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FireTruck",
                keyColumn: "IdFireTruck",
                keyValue: 3);

            migrationBuilder.AlterColumn<byte>(
                name: "SpecialEquipment",
                table: "FireTruck",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<byte>(
                name: "NeedSpecialEquipment",
                table: "Action",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
