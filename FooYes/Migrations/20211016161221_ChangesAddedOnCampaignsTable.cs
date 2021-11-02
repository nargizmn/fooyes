using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class ChangesAddedOnCampaignsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantCampaigns");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CampaignId",
                table: "Restaurants",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Campaigns_CampaignId",
                table: "Restaurants",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Campaigns_CampaignId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CampaignId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Restaurants");

            migrationBuilder.CreateTable(
                name: "RestaurantCampaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCampaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantCampaigns_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCampaigns_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCampaigns_CampaignId",
                table: "RestaurantCampaigns",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCampaigns_RestaurantId",
                table: "RestaurantCampaigns",
                column: "RestaurantId");
        }
    }
}
