using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdService.Infrastructure.Persistence.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3D39EE2F-950C-49CB-BAB1-C3DE9E6446C6", "593E74F5-8489-42AA-85C9-2863F72D8374", "Worker", "WORKER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56940798-D271-401E-8567-4C823BF87711", "21A2B715-F013-46EF-A378-B25DA1291E51", "Client", "CLIENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "D850E215-F047-41C4-A036-FEB0020173DB", "A25D90F6-F95C-473C-AB27-F2FD5B156058", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3D39EE2F-950C-49CB-BAB1-C3DE9E6446C6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56940798-D271-401E-8567-4C823BF87711");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "D850E215-F047-41C4-A036-FEB0020173DB");
        }
    }
}
