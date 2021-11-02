using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class OrderColumnAddedOnMealTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "MealTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "MealTypes");
        }
    }
}
