using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeBannerSecBtnText",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HomeBannerSecRedirectUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HomeOrderSecBtnText",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "HomeOrderSecRedirectUrl",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WorkWithUsHeroSecBtnText",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WorkWithUsHeroSecRedirectUrl",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "ContactHeroSecBgImg",
                table: "Settings",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTerms",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobTerms",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "ContactHeroSecBgImg",
                table: "Settings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeBannerSecBtnText",
                table: "Settings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeBannerSecRedirectUrl",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeOrderSecBtnText",
                table: "Settings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeOrderSecRedirectUrl",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkWithUsHeroSecBtnText",
                table: "Settings",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkWithUsHeroSecRedirectUrl",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
