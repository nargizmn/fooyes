using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class OrderFeatureJobFeatureFaqEmailSubscriberAndContactCardTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(maxLength: 200, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 300, nullable: false),
                    WorkingHours = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailSubscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSubscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(maxLength: 100, nullable: false),
                    Answer = table.Column<string>(maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Desc = table.Column<string>(maxLength: 300, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(maxLength: 300, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderFeatures", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCards");

            migrationBuilder.DropTable(
                name: "EmailSubscribers");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "JobFeatures");

            migrationBuilder.DropTable(
                name: "OrderFeatures");
        }
    }
}
