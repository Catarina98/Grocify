using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GrocifyApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDarkMode = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DefaultInventory = table.Column<bool>(type: "bit", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ChoosenDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyView = table.Column<bool>(type: "bit", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMeasures_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSections_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Difficult = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DefaultList = table.Column<bool>(type: "bit", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingLists_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserHouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultHouse = table.Column<bool>(type: "bit", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHouses_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserHouses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProductMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ProductMeasures_ProductMeasureId",
                        column: x => x.ProductMeasureId,
                        principalTable: "ProductMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductSections_ProductSectionId",
                        column: x => x.ProductSectionId,
                        principalTable: "ProductSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Steps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanMealRecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMealRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanMealRecipes_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMealRecipes_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanMealRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryProducts_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListProducts_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductMeasures",
                columns: new[] { "Id", "HouseId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"), null, false, "g" },
                    { new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), null, false, "ml" },
                    { new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"), null, false, "unit" },
                    { new Guid("f0e88aa9-6d2f-4c88-a3fc-7543647d7ae1"), null, false, "tbsp" }
                });

            migrationBuilder.InsertData(
                table: "ProductSections",
                columns: new[] { "Id", "HouseId", "Icon", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"), null, "dairy.svg", false, "Dairy" },
                    { new Guid("38f03e29-8b04-4df3-a58b-7a8b5e912a95"), null, "fishmonger.svg", false, "Fishmonger" },
                    { new Guid("5dcbf088-2b6e-4d03-845d-8564f2d6b19c"), null, "home.svg", false, "Home" },
                    { new Guid("72c6b5e5-9c7a-4345-9eb5-6f3a402ef4fd"), null, "meat.svg", false, "Meat" },
                    { new Guid("76a0cbe1-6d25-40c9-9cf5-430cd7e69d6d"), null, "personalcare.svg", false, "Personal Care & Health" },
                    { new Guid("8f3a95f1-6b96-43b7-9f62-d3f3db4f0bf1"), null, "drinks.svg", false, "Drinks" },
                    { new Guid("9a7cf8d1-8b57-4a37-90d5-06e5b4a33a1f"), null, "salty.svg", false, "Salty Grocery" },
                    { new Guid("a1e9b4cb-946e-4ec5-927d-576c92b5b8f9"), null, "takeaway.svg", false, "Takeaway" },
                    { new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880"), null, "fruits.svg", false, "Fruits and Vegetables" },
                    { new Guid("c44b52e7-19a2-4e4a-8dcb-bbe9cc5bb2e5"), null, "bakery.svg", false, "Bakery" },
                    { new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865"), null, "sweet.svg", false, "Sweet Grocery" },
                    { new Guid("ef3705e2-38e6-4ec8-8a06-8e3802d10ec5"), null, "frozenfood.svg", false, "Frozen food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "HouseId", "IsDeleted", "Name", "ProductMeasureId", "ProductSectionId" },
                values: new object[,]
                {
                    { new Guid("37bf06c3-d670-4ea7-9d54-815157f653f7"), null, false, "Milk", new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865") },
                    { new Guid("452349cd-7cf8-4e52-916f-3fda94eab413"), null, false, "Sugar", new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"), new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865") },
                    { new Guid("9fca6f9a-ae7b-4cb4-bba0-2d2b4f16e5c2"), null, false, "Egg", new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865") },
                    { new Guid("bd50a227-79db-4a7e-899c-1b0581c5931a"), null, false, "Apple", new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"), new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directions_RecipeId",
                table: "Directions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_HouseId",
                table: "Inventories",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_InventoryId",
                table: "InventoryProducts",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProducts_ProductId",
                table: "InventoryProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_HouseId",
                table: "Meals",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMealRecipes_MealId",
                table: "PlanMealRecipes",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMealRecipes_PlanId",
                table: "PlanMealRecipes",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMealRecipes_RecipeId",
                table: "PlanMealRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_HouseId",
                table: "Plans",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_HouseId",
                table: "ProductMeasures",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasures_Name_HouseId",
                table: "ProductMeasures",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_HouseId",
                table: "Products",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name_HouseId",
                table: "Products",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMeasureId",
                table: "Products",
                column: "ProductMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSectionId",
                table: "Products",
                column: "ProductSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_HouseId",
                table: "ProductSections",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSections_Name_HouseId",
                table: "ProductSections",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_ProductId",
                table: "RecipeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_RecipeId",
                table: "RecipeProducts",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_HouseId",
                table: "Recipes",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ProductId",
                table: "ShoppingListProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListProducts_ShoppingListId_ProductId",
                table: "ShoppingListProducts",
                columns: new[] { "ShoppingListId", "ProductId" },
                unique: true,
                filter: "[ShoppingListId] IS NOT NULL AND [ProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_DefaultList_HouseId",
                table: "ShoppingLists",
                columns: new[] { "DefaultList", "HouseId" },
                unique: true,
                filter: "DefaultList = 1");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_HouseId",
                table: "ShoppingLists",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingLists_Name_HouseId",
                table: "ShoppingLists",
                columns: new[] { "Name", "HouseId" },
                unique: true,
                filter: "[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_DefaultHouse_UserId",
                table: "UserHouses",
                columns: new[] { "DefaultHouse", "UserId" },
                unique: true,
                filter: "DefaultHouse = 1");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_HouseId",
                table: "UserHouses",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHouses_UserId_HouseId",
                table: "UserHouses",
                columns: new[] { "UserId", "HouseId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [HouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "InventoryProducts");

            migrationBuilder.DropTable(
                name: "PlanMealRecipes");

            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "ShoppingListProducts");

            migrationBuilder.DropTable(
                name: "UserHouses");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProductMeasures");

            migrationBuilder.DropTable(
                name: "ProductSections");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
