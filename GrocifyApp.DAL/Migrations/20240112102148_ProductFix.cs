using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSections_ProductMeasureId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSectionId",
                table: "Products",
                column: "ProductSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_Name",
                table: "ProductMeasures",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSections_ProductSectionId",
                table: "Products",
                column: "ProductSectionId",
                principalTable: "ProductSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductSections_ProductSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductMeasures_Name",
                table: "ProductMeasures");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductSections_ProductMeasureId",
                table: "Products",
                column: "ProductMeasureId",
                principalTable: "ProductSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
