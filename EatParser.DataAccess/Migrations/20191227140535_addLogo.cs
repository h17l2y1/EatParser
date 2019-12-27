using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EatParser.DataAccess.Migrations
{
    public partial class addLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Sushis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Sets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Rols",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Pizzas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2019, 12, 27, 14, 5, 35, 102, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2019, 12, 27, 14, 5, 35, 102, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2019, 12, 27, 14, 5, 35, 102, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2019, 12, 27, 14, 5, 35, 102, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Sushis");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Rols");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Pizzas");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2019, 12, 10, 14, 30, 58, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2019, 12, 10, 14, 30, 58, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2019, 12, 10, 14, 30, 58, 119, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2019, 12, 10, 14, 30, 58, 119, DateTimeKind.Utc));
        }
    }
}
