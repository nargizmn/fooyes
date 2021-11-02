using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class SettingsTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderLogo = table.Column<string>(maxLength: 50, nullable: true),
                    HeaderColorfulLogo = table.Column<string>(maxLength: 50, nullable: true),
                    HomeHeroSecBgImg = table.Column<string>(maxLength: 50, nullable: true),
                    HomeHeroSecTitle = table.Column<string>(maxLength: 100, nullable: true),
                    HomeHeroSecSubtitle = table.Column<string>(maxLength: 200, nullable: true),
                    HomeBannerSecBgImg = table.Column<string>(maxLength: 50, nullable: true),
                    HomeBannerSecTitle = table.Column<string>(maxLength: 100, nullable: true),
                    HomeBannerSecSubtitle = table.Column<string>(maxLength: 200, nullable: true),
                    HomeBannerSecDesc = table.Column<string>(maxLength: 200, nullable: true),
                    HomeBannerSecBtnText = table.Column<string>(maxLength: 25, nullable: true),
                    HomeBannerSecRedirectUrl = table.Column<string>(maxLength: 100, nullable: true),
                    HomeOrderSecTitle = table.Column<string>(maxLength: 100, nullable: true),
                    HomeOrderSecSubtitle1 = table.Column<string>(maxLength: 300, nullable: true),
                    HomeOrderSecSubtitle2 = table.Column<string>(maxLength: 300, nullable: true),
                    HomeOrderSecBtnText = table.Column<string>(maxLength: 25, nullable: true),
                    HomeOrderSecRedirectUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    WorkWithUsHeroSecBgImg = table.Column<string>(maxLength: 50, nullable: true),
                    WorkWithUsHeroSecTitle = table.Column<string>(maxLength: 100, nullable: true),
                    WorkWithUsHeroSecSubtitle = table.Column<string>(maxLength: 200, nullable: true),
                    WorkWithUsHeroSecBtnText = table.Column<string>(maxLength: 25, nullable: true),
                    WorkWithUsHeroSecRedirectUrl = table.Column<string>(maxLength: 100, nullable: true),
                    ContactHeroSecBgImg = table.Column<string>(maxLength: 50, nullable: true),
                    ContactHeroSecTitle = table.Column<string>(maxLength: 100, nullable: true),
                    ContactHeroSecSubtitle = table.Column<string>(maxLength: 200, nullable: true),
                    ContactMapUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
