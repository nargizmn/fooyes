using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class RidersTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Riders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: false),
                    VehicleType = table.Column<string>(nullable: false),
                    JobSource = table.Column<string>(nullable: false),
                    Fullname = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 25, nullable: false),
                    Telephone = table.Column<string>(maxLength: 13, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    TermsAccept = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Riders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Riders");
        }
    }
}
