using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FooYes.Migrations
{
    public partial class RestaurantsAndRelatedTablesCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountPercent = table.Column<double>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsTrending = table.Column<bool>(nullable: false),
                    IsPopular = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    ExtraCharge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    HasDelivery = table.Column<bool>(nullable: false),
                    HasTakeAway = table.Column<bool>(nullable: false),
                    IsRecommended = table.Column<bool>(nullable: false),
                    DeliveryFee = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Ingridients = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false),
                    MealTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meals_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCampaigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantId = table.Column<int>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RestaurantImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    IsMainImage = table.Column<bool>(nullable: false),
                    RestaurantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantImages_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealSizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(nullable: false),
                    SizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealSizes_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MealSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_RestaurantId",
                table: "Meals",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MealSizes_MealId",
                table: "MealSizes",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealSizes_SizeId",
                table: "MealSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCampaigns_CampaignId",
                table: "RestaurantCampaigns",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCampaigns_RestaurantId",
                table: "RestaurantCampaigns",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImages_RestaurantId",
                table: "RestaurantImages",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CategoryId",
                table: "Restaurants",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealSizes");

            migrationBuilder.DropTable(
                name: "RestaurantCampaigns");

            migrationBuilder.DropTable(
                name: "RestaurantImages");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
