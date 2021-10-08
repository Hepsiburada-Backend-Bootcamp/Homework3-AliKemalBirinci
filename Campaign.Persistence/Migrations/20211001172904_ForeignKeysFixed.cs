using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignApi.Migrations
{
    public partial class ForeignKeysFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroups_Campaigns_CampaignId",
                table: "ProductGroups");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroups_CampaignId",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "ProductGroups");

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

            migrationBuilder.CreateIndex(
                name: "IX_CampaignProductGroup_ProductGroupsId",
                table: "CampaignProductGroup",
                column: "ProductGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignProductGroup");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "ProductGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_CampaignId",
                table: "ProductGroups",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroups_Campaigns_CampaignId",
                table: "ProductGroups",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
