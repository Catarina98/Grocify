using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListDefaultListUniqueFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists",
                columns: new[] { "DefaultList", "HouseId" },
                unique: true,
                filter: "[DefaultList] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists",
                columns: new[] { "DefaultList", "HouseId" },
                unique: true,
                filter: "[DefaultList] IS NOT NULL AND [HouseId] IS NOT NULL");
        }
    }
}
