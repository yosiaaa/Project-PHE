using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSupplyManagement.Migrations
{
    public partial class NewestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ce19279-6263-44b7-a660-02abadb590bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ed449d4-18e7-48b7-a06d-8a51e0b7986a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5674b5be-e816-47ea-994d-25b3b0c71fc6", "0edbe5de-277d-4622-afb9-b559ae0938ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5ae95bb-e6d9-4db7-bd77-82f36381d573", "466bdfa9-6920-45ef-b609-d22381a4414c", "Vendor", "VENDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5674b5be-e816-47ea-994d-25b3b0c71fc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5ae95bb-e6d9-4db7-bd77-82f36381d573");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ce19279-6263-44b7-a660-02abadb590bf", "5a135b5d-5345-4b4b-adb6-696451a26270", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ed449d4-18e7-48b7-a06d-8a51e0b7986a", "b0ca0f65-ffe9-47d6-b2d6-3854b8a109c3", "Admin", "ADMIN" });
        }
    }
}
