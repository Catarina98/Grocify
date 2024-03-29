﻿// <auto-generated />
using System;
using GrocifyApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrocifyApp.DAL.Migrations
{
    [DbContext(typeof(GrocifyAppContext))]
    partial class GrocifyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrocifyApp.DAL.Models.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Direction", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Steps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("RecipeId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.House", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Inventory", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<bool>("DefaultInventory")
                        .HasColumnType("bit");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

                    b.HasIndex("DefaultInventory", "HouseId")
                        .IsUnique()
                        .HasFilter("DefaultInventory = 1");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.InventoryProduct", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasIndex("ProductId");

                    b.HasIndex("InventoryId", "ProductId")
                        .IsUnique()
                        .HasFilter("[InventoryId] IS NOT NULL AND [ProductId] IS NOT NULL");

                    b.ToTable("InventoryProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Meal", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.HasIndex("HouseId");

                    b.HasIndex("Color", "HouseId")
                        .IsUnique()
                        .HasFilter("[Color] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.HasIndex("OrderIndex", "HouseId")
                        .IsUnique()
                        .HasFilter("[OrderIndex] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Plan", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("ChoosenDays")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ChoosenDays");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("MonthlyView")
                        .HasColumnType("bit");

                    b.HasIndex("HouseId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.PlanMealRecipe", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("MealId");

                    b.HasIndex("PlanId");

                    b.HasIndex("RecipeId");

                    b.ToTable("PlanMealRecipes");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Product", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("ProductMeasureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("HouseId");

                    b.HasIndex("ProductMeasureId");

                    b.HasIndex("ProductSectionId");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd50a227-79db-4a7e-899c-1b0581c5931a"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Apple",
                            ProductMeasureId = new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"),
                            ProductSectionId = new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880")
                        },
                        new
                        {
                            Id = new Guid("452349cd-7cf8-4e52-916f-3fda94eab413"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sugar",
                            ProductMeasureId = new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"),
                            ProductSectionId = new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865")
                        },
                        new
                        {
                            Id = new Guid("37bf06c3-d670-4ea7-9d54-815157f653f7"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Milk",
                            ProductMeasureId = new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"),
                            ProductSectionId = new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865")
                        },
                        new
                        {
                            Id = new Guid("9fca6f9a-ae7b-4cb4-bba0-2d2b4f16e5c2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Egg",
                            ProductMeasureId = new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"),
                            ProductSectionId = new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865")
                        });
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductMeasure", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("ProductMeasures");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "g"
                        },
                        new
                        {
                            Id = new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "ml"
                        },
                        new
                        {
                            Id = new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "unit"
                        },
                        new
                        {
                            Id = new Guid("f0e88aa9-6d2f-4c88-a3fc-7543647d7ae1"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "tbsp"
                        });
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductSection", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("ProductSections");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5dcbf088-2b6e-4d03-845d-8564f2d6b19c"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Home",
                            Name = "Home"
                        },
                        new
                        {
                            Id = new Guid("38f03e29-8b04-4df3-a58b-7a8b5e912a95"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Fishmonger",
                            Name = "Fishmonger"
                        },
                        new
                        {
                            Id = new Guid("72c6b5e5-9c7a-4345-9eb5-6f3a402ef4fd"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Meat",
                            Name = "Meat"
                        },
                        new
                        {
                            Id = new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Sweetgrocery",
                            Name = "Sweet Grocery"
                        },
                        new
                        {
                            Id = new Guid("9a7cf8d1-8b57-4a37-90d5-06e5b4a33a1f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Saltygrocery",
                            Name = "Salty Grocery"
                        },
                        new
                        {
                            Id = new Guid("ef3705e2-38e6-4ec8-8a06-8e3802d10ec5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "FrozenFood",
                            Name = "Frozen food"
                        },
                        new
                        {
                            Id = new Guid("76a0cbe1-6d25-40c9-9cf5-430cd7e69d6d"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "PersonalCare",
                            Name = "Personal Care & Health"
                        },
                        new
                        {
                            Id = new Guid("c44b52e7-19a2-4e4a-8dcb-bbe9cc5bb2e5"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Bakery",
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Dairy",
                            Name = "Dairy"
                        },
                        new
                        {
                            Id = new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "FruitsVegetables",
                            Name = "Fruits and Vegetables"
                        },
                        new
                        {
                            Id = new Guid("8f3a95f1-6b96-43b7-9f62-d3f3db4f0bf1"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Drinks",
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = new Guid("a1e9b4cb-946e-4ec5-927d-576c92b5b8f9"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDeleted = false,
                            ModifiedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "Takeaway",
                            Name = "Takeaway"
                        });
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Recipe", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<int>("Difficult")
                        .HasColumnType("int");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasIndex("HouseId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.RecipeProduct", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Measure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ShoppingList", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<bool>("DefaultList")
                        .HasColumnType("bit");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

                    b.HasIndex("DefaultList", "HouseId")
                        .IsUnique()
                        .HasFilter("DefaultList = 1");

                    b.HasIndex("Name", "HouseId")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ShoppingListProduct", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ShoppingListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingListId", "ProductId")
                        .IsUnique()
                        .HasFilter("[ShoppingListId] IS NOT NULL AND [ProductId] IS NOT NULL");

                    b.ToTable("ShoppingListProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.User", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.UserHouse", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<bool>("DefaultHouse")
                        .HasColumnType("bit");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("HouseId");

                    b.HasIndex("DefaultHouse", "UserId")
                        .IsUnique()
                        .HasFilter("DefaultHouse = 1");

                    b.HasIndex("UserId", "HouseId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL AND [HouseId] IS NOT NULL");

                    b.ToTable("UserHouses");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Direction", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.Recipe", "Recipe")
                        .WithMany("Directions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Inventory", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Inventories")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.InventoryProduct", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.Inventory", "Inventory")
                        .WithMany("InventoryProducts")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrocifyApp.DAL.Models.Product", "Product")
                        .WithMany("InventoryProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Meal", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Meals")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Plan", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Plans")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.PlanMealRecipe", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.Meal", "Meal")
                        .WithMany("PlanMealRecipes")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrocifyApp.DAL.Models.Plan", "Plan")
                        .WithMany("PlanMealRecipes")
                        .HasForeignKey("PlanId");

                    b.HasOne("GrocifyApp.DAL.Models.Recipe", "Recipe")
                        .WithMany("PlanMealRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Plan");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Product", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Products")
                        .HasForeignKey("HouseId");

                    b.HasOne("GrocifyApp.DAL.Models.ProductMeasure", "ProductMeasure")
                        .WithMany("Products")
                        .HasForeignKey("ProductMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrocifyApp.DAL.Models.ProductSection", "ProductSection")
                        .WithMany("Products")
                        .HasForeignKey("ProductSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("ProductMeasure");

                    b.Navigation("ProductSection");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductMeasure", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("ProductMeasures")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductSection", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("ProductSections")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Recipe", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Recipes")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.RecipeProduct", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.Product", "Product")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("ProductId");

                    b.HasOne("GrocifyApp.DAL.Models.Recipe", "Recipe")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ShoppingList", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("ShoppingLists")
                        .HasForeignKey("HouseId");

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ShoppingListProduct", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.Product", "Product")
                        .WithMany("ShoppingListProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrocifyApp.DAL.Models.ShoppingList", "ShoppingList")
                        .WithMany("ShoppingListProducts")
                        .HasForeignKey("ShoppingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingList");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.UserHouse", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("UserHouses")
                        .HasForeignKey("HouseId");

                    b.HasOne("GrocifyApp.DAL.Models.User", "User")
                        .WithMany("UserHouses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.House", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Meals");

                    b.Navigation("Plans");

                    b.Navigation("ProductMeasures");

                    b.Navigation("ProductSections");

                    b.Navigation("Products");

                    b.Navigation("Recipes");

                    b.Navigation("ShoppingLists");

                    b.Navigation("UserHouses");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Inventory", b =>
                {
                    b.Navigation("InventoryProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Meal", b =>
                {
                    b.Navigation("PlanMealRecipes");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Plan", b =>
                {
                    b.Navigation("PlanMealRecipes");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Product", b =>
                {
                    b.Navigation("InventoryProducts");

                    b.Navigation("RecipeProducts");

                    b.Navigation("ShoppingListProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductMeasure", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductSection", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Recipe", b =>
                {
                    b.Navigation("Directions");

                    b.Navigation("PlanMealRecipes");

                    b.Navigation("RecipeProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ShoppingList", b =>
                {
                    b.Navigation("ShoppingListProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.User", b =>
                {
                    b.Navigation("UserHouses");
                });
#pragma warning restore 612, 618
        }
    }
}
