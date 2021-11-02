using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class NewColumnsAddedOnRestaurantsAndCommentsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodRate",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceRate",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PunctualityRate",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRate",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodRate",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceRate",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PunctualityRate",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceRate",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodRate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "PriceRate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "PunctualityRate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ServiceRate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "FoodRate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PriceRate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PunctualityRate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ServiceRate",
                table: "Comments");
        }
    }
}
