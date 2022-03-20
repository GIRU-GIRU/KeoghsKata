using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeoghsKata.Migrations
{
    public partial class InsertPromotionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.CreateTable(
                name: "PromotionStoreKeepingUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PromotionType = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreKeepingUnitId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUTC = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionStoreKeepingUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionStoreKeepingUnits_StoreKeepingUnits_StoreKeepingUnitId",
                        column: x => x.StoreKeepingUnitId,
                        principalTable: "StoreKeepingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PromotionStoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "PromotionType", "StoreKeepingUnitId" },
                values: new object[] { 1, new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1188), 1, 2 });

            migrationBuilder.InsertData(
                table: "PromotionStoreKeepingUnits",
                columns: new[] { "Id", "CreatedUTC", "PromotionType", "StoreKeepingUnitId" },
                values: new object[] { 2, new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1189), 2, 4 });

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1112));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 10, 6, 41, 895, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.CreateIndex(
                name: "IX_PromotionStoreKeepingUnits_StoreKeepingUnitId",
                table: "PromotionStoreKeepingUnits",
                column: "StoreKeepingUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionStoreKeepingUnits");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreKeepingUnitId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedUTC = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PromotionType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_StoreKeepingUnits_StoreKeepingUnitId",
                        column: x => x.StoreKeepingUnitId,
                        principalTable: "StoreKeepingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4851));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4853));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4854));

            migrationBuilder.UpdateData(
                table: "StoreKeepingUnits",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedUTC",
                value: new DateTime(2022, 3, 20, 7, 36, 58, 144, DateTimeKind.Utc).AddTicks(4855));

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_StoreKeepingUnitId",
                table: "Promotions",
                column: "StoreKeepingUnitId");
        }
    }
}
