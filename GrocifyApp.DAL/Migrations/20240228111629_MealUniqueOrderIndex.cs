using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MealUniqueOrderIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Meals_Name_HouseId",
                table: "Meals",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_OrderIndex_HouseId",
                table: "Meals",
                columns: new[] { "OrderIndex", "HouseId" },
                unique: true,
                filter: "[OrderIndex] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Meals_Name_HouseId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_OrderIndex_HouseId",
                table: "Meals");
        }
    }
}
