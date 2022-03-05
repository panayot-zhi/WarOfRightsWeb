using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Migrations
{
    public partial class RemoveWeaponPercent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "percent",
                table: "map_regiment_weapon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "percent",
                table: "map_regiment_weapon",
                type: "int",
                nullable: true);
        }
    }
}
