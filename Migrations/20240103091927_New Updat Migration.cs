using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSupplyManagement.Migrations
{
    public partial class NewUpdatMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46dc2109-7569-4b0f-8694-50d8254c5499");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556c0b49-3be7-4e75-8f49-bb8e600056b0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ce19279-6263-44b7-a660-02abadb590bf", "5a135b5d-5345-4b4b-adb6-696451a26270", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ed449d4-18e7-48b7-a06d-8a51e0b7986a", "b0ca0f65-ffe9-47d6-b2d6-3854b8a109c3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "46dc2109-7569-4b0f-8694-50d8254c5499", "17e85366-4b8e-4ab5-9e68-363a30980902", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "556c0b49-3be7-4e75-8f49-bb8e600056b0", "ffcdffa4-a8e1-488c-961a-684e3db25c31", "Admin", "ADMIN" });
        }
    }
}
