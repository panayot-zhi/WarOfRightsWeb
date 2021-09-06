using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Data.Migrations
{
    public partial class SnakeCaseNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MapRegiment_Maps_MapID",
                table: "MapRegiment");

            migrationBuilder.DropForeignKey(
                name: "FK_MapRegiment_Regiments_RegimentID",
                table: "MapRegiment");

            migrationBuilder.DropForeignKey(
                name: "FK_MapRegimentWeapon_MapRegiment_MapRegimentID",
                table: "MapRegimentWeapon");

            migrationBuilder.DropForeignKey(
                name: "FK_MapRegimentWeapon_Weapons_WeaponID",
                table: "MapRegimentWeapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regiments",
                table: "Regiments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapRegimentWeapon",
                table: "MapRegimentWeapon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapRegiment",
                table: "MapRegiment");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "weapons");

            migrationBuilder.RenameTable(
                name: "Regiments",
                newName: "regiments");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "maps");

            migrationBuilder.RenameTable(
                name: "MapRegimentWeapon",
                newName: "map_regiment_weapon");

            migrationBuilder.RenameTable(
                name: "MapRegiment",
                newName: "map_regiment");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "weapons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "weapons",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "weapons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ParametersDescription",
                table: "weapons",
                newName: "parameters_description");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "regiments",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "regiments",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "regiments",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "regiments",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Faction",
                table: "regiments",
                newName: "faction");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "regiments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "regiments",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "maps",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "maps",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "maps",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "maps",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WaveTime",
                table: "maps",
                newName: "wave_time");

            migrationBuilder.RenameColumn(
                name: "TransferOnDeath",
                table: "maps",
                newName: "transfer_on_death");

            migrationBuilder.RenameColumn(
                name: "TicketsUSA",
                table: "maps",
                newName: "tickets_usa");

            migrationBuilder.RenameColumn(
                name: "TicketsCSA",
                table: "maps",
                newName: "tickets_csa");

            migrationBuilder.RenameColumn(
                name: "SpawnImagePath",
                table: "maps",
                newName: "spawn_image_path");

            migrationBuilder.RenameColumn(
                name: "SkirmishImagePath",
                table: "maps",
                newName: "skirmish_image_path");

            migrationBuilder.RenameColumn(
                name: "RoundTime",
                table: "maps",
                newName: "round_time");

            migrationBuilder.RenameColumn(
                name: "NeutralizeSpeed",
                table: "maps",
                newName: "neutralize_speed");

            migrationBuilder.RenameColumn(
                name: "LoadingImagePath",
                table: "maps",
                newName: "loading_image_path");

            migrationBuilder.RenameColumn(
                name: "FinalPushTime",
                table: "maps",
                newName: "final_push_time");

            migrationBuilder.RenameColumn(
                name: "DefendingTeam",
                table: "maps",
                newName: "defending_team");

            migrationBuilder.RenameColumn(
                name: "DateTimeDescription",
                table: "maps",
                newName: "date_time_description");

            migrationBuilder.RenameColumn(
                name: "CaptureSpeed",
                table: "maps",
                newName: "capture_speed");

            migrationBuilder.RenameColumn(
                name: "AreaName",
                table: "maps",
                newName: "area_name");

            migrationBuilder.RenameColumn(
                name: "Percent",
                table: "map_regiment_weapon",
                newName: "percent");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "map_regiment_weapon",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "map_regiment_weapon",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WeaponID",
                table: "map_regiment_weapon",
                newName: "weapon_id");

            migrationBuilder.RenameColumn(
                name: "MapRegimentID",
                table: "map_regiment_weapon",
                newName: "map_regiment_id");

            migrationBuilder.RenameIndex(
                name: "IX_MapRegimentWeapon_MapRegimentID_WeaponID",
                table: "map_regiment_weapon",
                newName: "ix_map_regiment_weapon_map_regiment_id_weapon_id");

            migrationBuilder.RenameIndex(
                name: "IX_MapRegimentWeapon_WeaponID",
                table: "map_regiment_weapon",
                newName: "ix_map_regiment_weapon_weapon_id");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "map_regiment",
                newName: "order");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "map_regiment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RegimentID",
                table: "map_regiment",
                newName: "regiment_id");

            migrationBuilder.RenameColumn(
                name: "MapID",
                table: "map_regiment",
                newName: "map_id");

            migrationBuilder.RenameIndex(
                name: "IX_MapRegiment_MapID_RegimentID",
                table: "map_regiment",
                newName: "ix_map_regiment_map_id_regiment_id");

            migrationBuilder.RenameIndex(
                name: "IX_MapRegiment_RegimentID",
                table: "map_regiment",
                newName: "ix_map_regiment_regiment_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_weapons",
                table: "weapons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_regiments",
                table: "regiments",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_maps",
                table: "maps",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_map_regiment_weapon",
                table: "map_regiment_weapon",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_map_regiment",
                table: "map_regiment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_map_regiment_maps_map_id",
                table: "map_regiment",
                column: "map_id",
                principalTable: "maps",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_map_regiment_regiments_regiment_id",
                table: "map_regiment",
                column: "regiment_id",
                principalTable: "regiments",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_map_regiment_weapon_map_regiment_map_regiment_id",
                table: "map_regiment_weapon",
                column: "map_regiment_id",
                principalTable: "map_regiment",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_map_regiment_weapon_weapons_weapon_id",
                table: "map_regiment_weapon",
                column: "weapon_id",
                principalTable: "weapons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_map_regiment_maps_map_id",
                table: "map_regiment");

            migrationBuilder.DropForeignKey(
                name: "fk_map_regiment_regiments_regiment_id",
                table: "map_regiment");

            migrationBuilder.DropForeignKey(
                name: "fk_map_regiment_weapon_map_regiment_map_regiment_id",
                table: "map_regiment_weapon");

            migrationBuilder.DropForeignKey(
                name: "fk_map_regiment_weapon_weapons_weapon_id",
                table: "map_regiment_weapon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_weapons",
                table: "weapons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_regiments",
                table: "regiments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_maps",
                table: "maps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_map_regiment_weapon",
                table: "map_regiment_weapon");

            migrationBuilder.DropPrimaryKey(
                name: "pk_map_regiment",
                table: "map_regiment");

            migrationBuilder.RenameTable(
                name: "weapons",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "regiments",
                newName: "Regiments");

            migrationBuilder.RenameTable(
                name: "maps",
                newName: "Maps");

            migrationBuilder.RenameTable(
                name: "map_regiment_weapon",
                newName: "MapRegimentWeapon");

            migrationBuilder.RenameTable(
                name: "map_regiment",
                newName: "MapRegiment");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Weapons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Weapons",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Weapons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "parameters_description",
                table: "Weapons",
                newName: "ParametersDescription");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Regiments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Regiments",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Regiments",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Regiments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "faction",
                table: "Regiments",
                newName: "Faction");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Regiments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Regiments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "Maps",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Maps",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Maps",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Maps",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "wave_time",
                table: "Maps",
                newName: "WaveTime");

            migrationBuilder.RenameColumn(
                name: "transfer_on_death",
                table: "Maps",
                newName: "TransferOnDeath");

            migrationBuilder.RenameColumn(
                name: "tickets_usa",
                table: "Maps",
                newName: "TicketsUSA");

            migrationBuilder.RenameColumn(
                name: "tickets_csa",
                table: "Maps",
                newName: "TicketsCSA");

            migrationBuilder.RenameColumn(
                name: "spawn_image_path",
                table: "Maps",
                newName: "SpawnImagePath");

            migrationBuilder.RenameColumn(
                name: "skirmish_image_path",
                table: "Maps",
                newName: "SkirmishImagePath");

            migrationBuilder.RenameColumn(
                name: "round_time",
                table: "Maps",
                newName: "RoundTime");

            migrationBuilder.RenameColumn(
                name: "neutralize_speed",
                table: "Maps",
                newName: "NeutralizeSpeed");

            migrationBuilder.RenameColumn(
                name: "loading_image_path",
                table: "Maps",
                newName: "LoadingImagePath");

            migrationBuilder.RenameColumn(
                name: "final_push_time",
                table: "Maps",
                newName: "FinalPushTime");

            migrationBuilder.RenameColumn(
                name: "defending_team",
                table: "Maps",
                newName: "DefendingTeam");

            migrationBuilder.RenameColumn(
                name: "date_time_description",
                table: "Maps",
                newName: "DateTimeDescription");

            migrationBuilder.RenameColumn(
                name: "capture_speed",
                table: "Maps",
                newName: "CaptureSpeed");

            migrationBuilder.RenameColumn(
                name: "area_name",
                table: "Maps",
                newName: "AreaName");

            migrationBuilder.RenameColumn(
                name: "percent",
                table: "MapRegimentWeapon",
                newName: "Percent");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "MapRegimentWeapon",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MapRegimentWeapon",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "weapon_id",
                table: "MapRegimentWeapon",
                newName: "WeaponID");

            migrationBuilder.RenameColumn(
                name: "map_regiment_id",
                table: "MapRegimentWeapon",
                newName: "MapRegimentID");

            migrationBuilder.RenameIndex(
                name: "ix_map_regiment_weapon_map_regiment_id_weapon_id",
                table: "MapRegimentWeapon",
                newName: "IX_MapRegimentWeapon_MapRegimentID_WeaponID");

            migrationBuilder.RenameIndex(
                name: "ix_map_regiment_weapon_weapon_id",
                table: "MapRegimentWeapon",
                newName: "IX_MapRegimentWeapon_WeaponID");

            migrationBuilder.RenameColumn(
                name: "order",
                table: "MapRegiment",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MapRegiment",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "regiment_id",
                table: "MapRegiment",
                newName: "RegimentID");

            migrationBuilder.RenameColumn(
                name: "map_id",
                table: "MapRegiment",
                newName: "MapID");

            migrationBuilder.RenameIndex(
                name: "ix_map_regiment_map_id_regiment_id",
                table: "MapRegiment",
                newName: "IX_MapRegiment_MapID_RegimentID");

            migrationBuilder.RenameIndex(
                name: "ix_map_regiment_regiment_id",
                table: "MapRegiment",
                newName: "IX_MapRegiment_RegimentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regiments",
                table: "Regiments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapRegimentWeapon",
                table: "MapRegimentWeapon",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapRegiment",
                table: "MapRegiment",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MapRegiment_Maps_MapID",
                table: "MapRegiment",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MapRegiment_Regiments_RegimentID",
                table: "MapRegiment",
                column: "RegimentID",
                principalTable: "Regiments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MapRegimentWeapon_MapRegiment_MapRegimentID",
                table: "MapRegimentWeapon",
                column: "MapRegimentID",
                principalTable: "MapRegiment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MapRegimentWeapon_Weapons_WeaponID",
                table: "MapRegimentWeapon",
                column: "WeaponID",
                principalTable: "Weapons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
