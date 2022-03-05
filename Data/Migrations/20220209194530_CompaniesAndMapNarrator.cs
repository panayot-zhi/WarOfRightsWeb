using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Migrations
{
    public partial class CompaniesAndMapNarrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companies",
                table: "regiments",
                maxLength: 127,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "narrator_info",
                table: "maps",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companies",
                table: "regiments");

            migrationBuilder.DropColumn(
                name: "narrator_info",
                table: "maps");
        }
    }
}
