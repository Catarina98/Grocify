using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListProductUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingListProducts_ShoppingListId",
                table: "ShoppingListProducts");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ShoppingListId_ProductId",
                table: "ShoppingListProducts",
                columns: new[] { "ShoppingListId", "ProductId" },
                unique: true,
                filter: "[ShoppingListId] IS NOT NULL AND [ProductId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingListProducts_ShoppingListId_ProductId",
                table: "ShoppingListProducts");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ShoppingListId",
                table: "ShoppingListProducts",
                column: "ShoppingListId");
        }
    }
}
