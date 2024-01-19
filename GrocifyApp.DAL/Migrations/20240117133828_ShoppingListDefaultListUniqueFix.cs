using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListDefaultListUniqueFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_DefaultList",
                table: "ShoppingLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists",
                columns: new[] { "DefaultList", "HouseId" },
                unique: true,
                filter: "[DefaultList] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList",
                table: "ShoppingLists",
                column: "DefaultList",
                unique: true,
                filter: "[DefaultList] IS NOT NULL");
        }
    }
}
