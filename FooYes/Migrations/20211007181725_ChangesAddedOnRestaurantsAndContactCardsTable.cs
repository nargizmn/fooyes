using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnRestaurantsAndContactCardsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "ContactCards");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Restaurants",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "ContactCards",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "ContactCards");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Restaurants",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ContactCards",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
