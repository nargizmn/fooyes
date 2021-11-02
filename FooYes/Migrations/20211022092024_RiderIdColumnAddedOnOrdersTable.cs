using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class RiderIdColumnAddedOnOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiderId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RiderId",
                table: "Orders",
                column: "RiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Riders_RiderId",
                table: "Orders",
                column: "RiderId",
                principalTable: "Riders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Riders_RiderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RiderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RiderId",
                table: "Orders");
        }
    }
}
