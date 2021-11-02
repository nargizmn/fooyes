using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class NewColumnsAddedOnRidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Riders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Riders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Riders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Riders");
        }
    }
}
