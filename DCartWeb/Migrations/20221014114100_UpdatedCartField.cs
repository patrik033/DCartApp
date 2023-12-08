using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCartWeb.Migrations
{
    public partial class UpdatedCartField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "257f74b1-c3c6-4187-8a41-5e3cdfaaca6d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "6e3c90ec-e0df-4d85-866d-afb5f72ddb80");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c53474e-d7d1-498e-b328-912ffd0d023a", new DateTime(2022, 10, 14, 13, 40, 59, 828, DateTimeKind.Local).AddTicks(5118), "AQAAAAEAACcQAAAAEI82wwP2Ud3r++teusGM5lJqjfIQWv2oabIYVlbHznWpzH/DGv6dVWpONjJe2J2uhA==", "77655857-cc16-4604-af4f-93ecc7f35bb0" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5016));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4925));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 14, 11, 40, 59, 828, DateTimeKind.Utc).AddTicks(4927));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Carts");

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
    }
}
