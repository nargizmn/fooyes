using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DeliveryTime",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DeliveryTime",
                table: "Orders",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
