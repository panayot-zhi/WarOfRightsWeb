using Microsoft.EntityFrameworkCore.Migrations;

namespace WarOfRightsWeb.Data.Migrations
{
    public partial class RegimentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Regiments",
                maxLength: 127,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128) CHARACTER SET utf8mb4",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Regiments",
                maxLength: 127,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Faction",
                table: "Regiments",
                maxLength: 127,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128) CHARACTER SET utf8mb4",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Regiments",
                maxLength: 127,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DefendingTeam",
                table: "Maps",
                maxLength: 127,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(128) CHARACTER SET utf8mb4",
                oldMaxLength: 128,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Regiments");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Regiments",
                type: "varchar(128) CHARACTER SET utf8mb4",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 127,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Regiments",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 127,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Faction",
                table: "Regiments",
                type: "varchar(128) CHARACTER SET utf8mb4",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 127,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DefendingTeam",
                table: "Maps",
                type: "varchar(128) CHARACTER SET utf8mb4",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 127,
                oldNullable: true);
        }
    }
}
