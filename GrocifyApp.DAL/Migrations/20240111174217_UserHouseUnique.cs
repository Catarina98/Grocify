using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserHouseUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserHouses_UserId",
                table: "UserHouses");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_UserId_HouseId",
                table: "UserHouses",
                columns: new[] { "UserId", "HouseId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [HouseId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserHouses_UserId_HouseId",
                table: "UserHouses");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_UserId",
                table: "UserHouses",
                column: "UserId");
        }
    }
}
