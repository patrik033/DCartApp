using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCartWeb.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "9481aa9d-61b6-4b5b-ac22-8feab7836d2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "8d97899c-3d80-484f-8bfb-d4c9d87ae52f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b76c3bf3-c667-4aa9-9627-06185ee78021", new DateTime(2022, 10, 10, 19, 25, 8, 297, DateTimeKind.Local).AddTicks(7197), "AQAAAAEAACcQAAAAELCBnISR7lHPqVoZbNIX+lq2PL8gx1eqHvyQNDaZw7WIOdjvBC8cXZrMi6r/uvcv3A==", "c5df4718-f109-4aae-8810-57dea70d8c42" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6975));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6982));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 10, 17, 25, 8, 297, DateTimeKind.Utc).AddTicks(6985));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "bcb11c9d-779d-473e-8342-7a62404fa15e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "4f66cdd4-f7ee-4ece-a78f-b810653d1c24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2705e4b-ae0c-426f-8767-60841ef4db69", new DateTime(2022, 10, 7, 10, 40, 30, 817, DateTimeKind.Local).AddTicks(2999), "AQAAAAEAACcQAAAAEECbIK1g5TaOQ98JlfUKPcLWNutZznI9Iz/QnBCPb6tohTsMHMp2tzUXWIVsXZL1mQ==", "df458278-ecc4-43a0-8717-234964c69800" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2796));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2798));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2706));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2712));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2714));
        }
    }
}
