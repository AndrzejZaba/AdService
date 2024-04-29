using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdService.Infrastructure.Persistence.Migrations
{
    public partial class IsPrivateChangedToIsBusinessAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPrivateAccount",
                table: "Clients",
                newName: "IsBusinessAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsBusinessAccount",
                table: "Clients",
                newName: "IsPrivateAccount");
        }
    }
}
