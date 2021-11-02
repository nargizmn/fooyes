using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnRestaurantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ServiceRate",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "PunctualityRate",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "PriceRate",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "FoodRate",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ServiceRate",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PunctualityRate",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PriceRate",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FoodRate",
                table: "Restaurants",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
