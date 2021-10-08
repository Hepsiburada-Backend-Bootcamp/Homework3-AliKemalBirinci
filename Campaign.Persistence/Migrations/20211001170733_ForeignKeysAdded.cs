using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignApi.Migrations
{
    public partial class ForeignKeysAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Campaigns_CampaignId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CampaignId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Stores");

            migrationBuilder.AlterColumn<int>(
                name: "ProductGroupId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CampaignStore_StoresId",
                table: "CampaignStore",
                column: "StoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CampaignStore");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductGroupId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CampaignId",
                table: "Stores",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ProductGroupId",
                table: "Products",
                column: "ProductGroupId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Campaigns_CampaignId",
                table: "Stores",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
