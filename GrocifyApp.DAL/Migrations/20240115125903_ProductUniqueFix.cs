using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductUniqueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductMeasures_Name",
                table: "ProductMeasures");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name_HouseId",
                table: "ProductSections",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_HouseId",
                table: "Products",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_Name_HouseId",
                table: "ProductMeasures",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductSections_Name_HouseId",
                table: "ProductSections");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name_HouseId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductMeasures_Name_HouseId",
                table: "ProductMeasures");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_Name",
                table: "ProductMeasures",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
