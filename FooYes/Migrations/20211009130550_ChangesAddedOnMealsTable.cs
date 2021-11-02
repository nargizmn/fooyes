using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnMealsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealTypeId",
                table: "Meals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ingridients",
                table: "Meals",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Restaurants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealTypeId",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Ingridients",
                table: "Meals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
