using Microsoft.EntityFrameworkCore.Migrations;

namespace EatParser.DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameUsers",
                table: "GameUsers");

            migrationBuilder.RenameTable(
                name: "GameUsers",
                newName: "SushiSets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SushiSets",
                table: "SushiSets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SushiSets",
                table: "SushiSets");

            migrationBuilder.RenameTable(
                name: "SushiSets",
                newName: "GameUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameUsers",
                table: "GameUsers",
                column: "Id");
        }
    }
}
