using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class SizeIdColumnAddedOnBasketItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "BasketItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_SizeId",
                table: "BasketItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Sizes_SizeId",
                table: "BasketItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Sizes_SizeId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_SizeId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "BasketItems");
        }
    }
}
