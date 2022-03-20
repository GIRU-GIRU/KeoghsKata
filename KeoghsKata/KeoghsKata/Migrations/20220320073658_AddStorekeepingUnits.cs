using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeoghsKata.Migrations
{
    public partial class AddStorekeepingUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "ProductName", "UnitPrice" },
                values: new object[] { 1, new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4851), "A", 10m });

            migrationBuilder.InsertData(
                table: "StoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "ProductName", "UnitPrice" },
                values: new object[] { 2, new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4853), "B", 15m });

            migrationBuilder.InsertData(
                table: "StoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "ProductName", "UnitPrice" },
                values: new object[] { 3, new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4854), "C", 40m });

            migrationBuilder.InsertData(
                table: "StoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "ProductName", "UnitPrice" },
                values: new object[] { 4, new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4855), "D", 55m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
