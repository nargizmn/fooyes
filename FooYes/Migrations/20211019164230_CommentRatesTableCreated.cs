using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class CommentRatesTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    IsUseful = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentRates_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentRates_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_AppUserId",
                table: "CommentRates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRates_CommentId",
                table: "CommentRates",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentRates");
        }
    }
}
