using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateTimeDescription = table.Column<string>(maxLength: 256, nullable: true),
                    DefendingTeam = table.Column<string>(maxLength: 128, nullable: true),
                    TransferOnDeath = table.Column<decimal>(nullable: true),
                    RoundTime = table.Column<int>(nullable: true),
                    WaveTime = table.Column<int>(nullable: true),
                    CaptureSpeed = table.Column<decimal>(nullable: true),
                    NeutralizeSpeed = table.Column<decimal>(nullable: true),
                    TicketsUSA = table.Column<int>(nullable: true),
                    TicketsCSA = table.Column<int>(nullable: true),
                    FinalPushTime = table.Column<int>(nullable: true),
                    SkirmishImagePath = table.Column<string>(maxLength: 256, nullable: true),
                    SpawnImagePath = table.Column<string>(maxLength: 256, nullable: true),
                    LoadingImagePath = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Regiments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    Faction = table.Column<string>(maxLength: 128, nullable: true),
                    State = table.Column<string>(maxLength: 128, nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ParametersDescription = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MapRegiment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MapID = table.Column<int>(nullable: false),
                    RegimentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRegiment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MapRegiment_Maps_MapID",
                        column: x => x.MapID,
                        principalTable: "Maps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapRegiment_Regiments_RegimentID",
                        column: x => x.RegimentID,
                        principalTable: "Regiments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapRegimentWeapon",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MapRegimentID = table.Column<int>(nullable: false),
                    WeaponID = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: true),
                    Percent = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapRegimentWeapon", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MapRegimentWeapon_MapRegiment_MapRegimentID",
                        column: x => x.MapRegimentID,
                        principalTable: "MapRegiment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapRegimentWeapon_Weapons_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Weapons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapRegiment_RegimentID",
                table: "MapRegiment",
                column: "RegimentID");

            migrationBuilder.CreateIndex(
                name: "IX_MapRegiment_MapID_RegimentID",
                table: "MapRegiment",
                columns: new[] { "MapID", "RegimentID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapRegimentWeapon_WeaponID",
                table: "MapRegimentWeapon",
                column: "WeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_MapRegimentWeapon_MapRegimentID_WeaponID",
                table: "MapRegimentWeapon",
                columns: new[] { "MapRegimentID", "WeaponID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maps_Name",
                table: "Maps",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regiments_Name",
                table: "Regiments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Name",
                table: "Weapons",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapRegimentWeapon");

            migrationBuilder.DropTable(
                name: "MapRegiment");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Regiments");
        }
    }
}
