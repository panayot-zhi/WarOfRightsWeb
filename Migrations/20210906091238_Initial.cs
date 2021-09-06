using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "maps",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    area_name = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    date_time_description = table.Column<string>(maxLength: 255, nullable: true),
                    defending_team = table.Column<string>(maxLength: 127, nullable: true),
                    transfer_on_death = table.Column<decimal>(type: "DECIMAL(6,4)", nullable: true),
                    round_time = table.Column<int>(nullable: true),
                    wave_time = table.Column<int>(nullable: true),
                    capture_speed = table.Column<decimal>(type: "DECIMAL(6,4)", nullable: true),
                    neutralize_speed = table.Column<decimal>(type: "DECIMAL(6,4)", nullable: true),
                    tickets_usa = table.Column<int>(nullable: true),
                    tickets_csa = table.Column<int>(nullable: true),
                    final_push_time = table.Column<int>(nullable: true),
                    skirmish_image_path = table.Column<string>(maxLength: 255, nullable: true),
                    spawn_image_path = table.Column<string>(maxLength: 255, nullable: true),
                    loading_image_path = table.Column<string>(maxLength: 255, nullable: true),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_maps", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regiments",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    faction = table.Column<string>(maxLength: 127, nullable: true),
                    state = table.Column<string>(maxLength: 127, nullable: true),
                    number = table.Column<string>(maxLength: 127, nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    type = table.Column<string>(maxLength: 127, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regiments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    parameters_description = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weapons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "map_regiment",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    map_id = table.Column<string>(nullable: true),
                    regiment_id = table.Column<string>(nullable: true),
                    order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_map_regiment", x => x.id);
                    table.ForeignKey(
                        name: "fk_map_regiment_maps_map_id",
                        column: x => x.map_id,
                        principalTable: "maps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_map_regiment_regiments_regiment_id",
                        column: x => x.regiment_id,
                        principalTable: "regiments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "map_regiment_weapon",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    map_regiment_id = table.Column<string>(nullable: true),
                    weapon_id = table.Column<string>(nullable: true),
                    count = table.Column<int>(nullable: true),
                    percent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_map_regiment_weapon", x => x.id);
                    table.ForeignKey(
                        name: "fk_map_regiment_weapon_map_regiment_map_regiment_id",
                        column: x => x.map_regiment_id,
                        principalTable: "map_regiment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_map_regiment_weapon_weapons_weapon_id",
                        column: x => x.weapon_id,
                        principalTable: "weapons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_map_regiment_regiment_id",
                table: "map_regiment",
                column: "regiment_id");

            migrationBuilder.CreateIndex(
                name: "ix_map_regiment_map_id_regiment_id",
                table: "map_regiment",
                columns: new[] { "map_id", "regiment_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_map_regiment_weapon_weapon_id",
                table: "map_regiment_weapon",
                column: "weapon_id");

            migrationBuilder.CreateIndex(
                name: "ix_map_regiment_weapon_map_regiment_id_weapon_id",
                table: "map_regiment_weapon",
                columns: new[] { "map_regiment_id", "weapon_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "map_regiment_weapon");

            migrationBuilder.DropTable(
                name: "map_regiment");

            migrationBuilder.DropTable(
                name: "weapons");

            migrationBuilder.DropTable(
                name: "maps");

            migrationBuilder.DropTable(
                name: "regiments");
        }
    }
}
