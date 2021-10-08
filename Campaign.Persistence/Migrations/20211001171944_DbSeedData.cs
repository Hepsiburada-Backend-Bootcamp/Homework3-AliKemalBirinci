using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampaignApi.Migrations
{
    public partial class DbSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Id", "CampaignId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Monitors" },
                    { 2, null, "Others" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
