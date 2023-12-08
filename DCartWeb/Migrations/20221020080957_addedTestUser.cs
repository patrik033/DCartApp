using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DCartWeb.Migrations
{
    public partial class addedTestUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "ad13afe9-c05e-4337-a3cb-40d375815ad8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2e174e-1b0e-416f-83af-483d56fd7212",
                column: "ConcurrencyStamp",
                value: "d977af25-ab08-468e-9e00-9834697e9ea3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a3e134a-2c3a-446f-86af-112d26fd2890",
                columns: new[] { "ConcurrencyStamp", "DateAdded", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62f59136-a284-496f-80da-f3c57c49e9a0", new DateTime(2022, 10, 20, 10, 9, 56, 795, DateTimeKind.Local).AddTicks(3973), "AQAAAAEAACcQAAAAEIwiXP8+8Pq2hWnKZKBYoV6SQHGYnXwRUG5pAGYakHKWKlBJyeipR7G6aIVH99tvjA==", "e912c303-859f-43f6-ba04-87704fea0d9a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DateAdded", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a3e139a-1c7a-446f-86af-112d26fd2899", 0, null, "172612d6-4392-486d-a858-9c94e689d84d", new DateTime(2022, 10, 20, 10, 9, 56, 801, DateTimeKind.Local).AddTicks(4513), "User", "test.dcartapp@gmail.com", true, "Test", "Test", false, null, "TEST.DCARTAPP@GMAIL.COM", "TEST.DCARTAPP@GMAIL.COM", "AQAAAAEAACcQAAAAEMyHLevaOonLurUNBUq4VMFN1PEg7Nc2vuyv127Sl3Yg62lUCiye3VYm5ZIUQmCPIg==", null, false, null, "ad091906-5ce0-445b-9268-a34fb21a9bb0", false, "test.dcartapp@gmail.com" });

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3523));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "MainCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3822));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3686));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2022, 10, 20, 8, 9, 56, 795, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "9a3e139a-1c7a-446f-86af-112d26fd2899" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "9a3e139a-1c7a-446f-86af-112d26fd2899" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a3e139a-1c7a-446f-86af-112d26fd2899");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

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
    }
}
