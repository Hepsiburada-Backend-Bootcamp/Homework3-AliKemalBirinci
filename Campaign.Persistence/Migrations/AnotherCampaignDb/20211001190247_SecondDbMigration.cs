using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignApi.Migrations.AnotherCampaignDb
{
    public partial class SecondDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignProductGroup",
                columns: table => new
                {
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    ProductGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignProductGroup", x => new { x.CampaignsId, x.ProductGroupsId });
                    table.ForeignKey(
                        name: "FK_CampaignProductGroup_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignProductGroup_ProductGroups_ProductGroupsId",
                        column: x => x.ProductGroupsId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignStore",
                columns: table => new
                {
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignStore", x => new { x.CampaignsId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_CampaignStore_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignStore_Stores_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "Description", "EndDate", "IsActive", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "Ikinci ürün yüzde elli indirimli.", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monitor Kampanya", new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Ikinci ürün yüzde yirmi indirimli.", new DateTime(2022, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Others Kampanya", new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Monitors" },
                    { 2, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "Ankara", "AnkaMall" },
                    { 2, "Istanbul", "Akasya" },
                    { 3, "Istanbul", "Mall Of Ist" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductGroupId" },
                values: new object[,]
                {
                    { 1, "Apple iPad", 1000.0, 1 },
                    { 2, "Samsung Smart TV", 1500.0, 1 },
                    { 3, "Nokia 130", 1200.0, 1 },
                    { 4, "Dell Monitor", 800.0, 2 },
                    { 5, "Samsung Monitor", 1000.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignProductGroup_ProductGroupsId",
                table: "CampaignProductGroup",
                column: "ProductGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignStore_StoresId",
                table: "CampaignStore",
                column: "StoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupId",
                table: "Products",
                column: "ProductGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignProductGroup");

            migrationBuilder.DropTable(
                name: "CampaignStore");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
