using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Migrations
{
    public partial class RemoveMapObsoleteProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capture_speed",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "neutralize_speed",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "round_time",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "transfer_on_death",
                table: "maps");

            migrationBuilder.DropColumn(
                name: "wave_time",
                table: "maps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "capture_speed",
                table: "maps",
                type: "DECIMAL(6,4)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "neutralize_speed",
                table: "maps",
                type: "DECIMAL(6,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "round_time",
                table: "maps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "transfer_on_death",
                table: "maps",
                type: "DECIMAL(6,4)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wave_time",
                table: "maps",
                type: "int",
                nullable: true);
        }
    }
}
