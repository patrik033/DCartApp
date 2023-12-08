using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCartWeb.Migrations
{
    public partial class addedFieldTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPicture",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "CartItems");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Carts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2779), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2782), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2785), true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2787), true });

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2794), true });

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 10, 7, 8, 40, 30, 817, DateTimeKind.Utc).AddTicks(2805), true });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductPicture",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "OrderItems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "CartItems",
                type: "varbinary(max)",
                nullable: true);

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6971), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6974), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6976), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6977), false });

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6983), false });

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
                columns: new[] { "DateAdded", "IsFeatured" },
                values: new object[] { new DateTime(2022, 9, 28, 9, 31, 34, 718, DateTimeKind.Utc).AddTicks(6993), false });

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
    }
}
