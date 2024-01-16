using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductSectionUniqueRevert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name",
                table: "ProductSections",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
