using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserHouseDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DefaultHouse",
                table: "UserHouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_DefaultHouse_UserId",
                table: "UserHouses",
                columns: new[] { "DefaultHouse", "UserId" },
                unique: true,
                filter: "DefaultHouse = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserHouses_DefaultHouse_UserId",
                table: "UserHouses");

            migrationBuilder.DropColumn(
                name: "DefaultHouse",
                table: "UserHouses");
        }
    }
}
