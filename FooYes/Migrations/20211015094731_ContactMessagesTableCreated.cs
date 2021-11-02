using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ContactMessagesTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IsUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactMessages_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMessages_AppUserId",
                table: "ContactMessages",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMessages");
        }
    }
}
