using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Migrations
{
    public partial class MapType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "map_type",
                table: "maps",
                maxLength: 127,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "map_type",
                table: "maps");
        }
    }
}
