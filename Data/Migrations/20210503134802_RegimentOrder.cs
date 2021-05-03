using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Data.Migrations
{
    public partial class RegimentOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "MapRegiment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "MapRegiment");
        }
    }
}
