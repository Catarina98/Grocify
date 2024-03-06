using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InventoryUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryProducts_InventoryId",
                table: "InventoryProducts");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_InventoryId_ProductId",
                table: "InventoryProducts",
                columns: new[] { "InventoryId", "ProductId" },
                unique: true,
                filter: "[InventoryId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_DefaultInventory_HouseId",
                table: "Inventories",
                columns: new[] { "DefaultInventory", "HouseId" },
                unique: true,
                filter: "DefaultInventory = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_Name_HouseId",
                table: "Inventories",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryProducts_InventoryId_ProductId",
                table: "InventoryProducts");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_DefaultInventory_HouseId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_Name_HouseId",
                table: "Inventories");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_InventoryId",
                table: "InventoryProducts",
                column: "InventoryId");
        }
    }
}
