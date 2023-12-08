using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCartWeb.Migrations
{
    public partial class addedFieldIsFeatured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ca232e6b-8666-4bdb-899b-2e81538dff51");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "2f151351-945c-4940-9d09-d8e43a314471");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d3f62c9-e82d-4ba6-bfda-d1489dae0361", new DateTime(2022, 9, 28, 11, 31, 34, 718, DateTimeKind.Local).AddTicks(7102), "AQAAAAEAACcQAAAAENvnFbwMccapb1aS2sLBlR+Uq0jhPuiKy81+ZRcrR7dE14xcmfGkPXx97WxTNeRZBg==", "60119801-ab2d-4082-bf84-71733b16e99a" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6726));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6904));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "54720fa6-25eb-4d15-8162-1e00887bf6a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "8c81e784-a485-4c6a-b1b6-37eecc6a1ef5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "204a0eec-af3b-48b0-9982-d78a36036639", new DateTime(2022, 9, 26, 13, 2, 30, 581, DateTimeKind.Local).AddTicks(8226), "AQAAAAEAACcQAAAAEPJx5wgHzhZj5eIwA8HuIeHNWdA5JjcKvg38Vsb/lHs48wqeDqJvgC/bJHLlqC0I6w==", "faffa285-65ab-4551-a6ae-759cfb3f9051" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(7886));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(7888));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8117));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8122));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8124));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8136));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8138));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 9, 26, 11, 2, 30, 581, DateTimeKind.Utc).AddTicks(8021));
        }
    }
}
