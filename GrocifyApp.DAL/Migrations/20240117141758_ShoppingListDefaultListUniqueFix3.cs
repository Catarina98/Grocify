using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingListDefaultListUniqueFix3 : Migration
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
                filter: "DefaultList = 1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_Name_HouseId",
                table: "ShoppingLists",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingLists_Name_HouseId",
                table: "ShoppingLists");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists",
                columns: new[] { "DefaultList", "HouseId" },
                unique: true,
                filter: "[DefaultList] = 1");
        }
    }
}
