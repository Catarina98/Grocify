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

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

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

                    b.HasIndex("InventoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("InventoryProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Meal", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("OrderIndex")
                        .HasColumnType("int");

                    b.HasIndex("HouseId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Plan", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("ChoosenDays")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ChoosenDays");

                    b.Property<Guid>("HouseId")
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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("ProductMeasureId");

                    b.HasIndex("ProductSectionId");

                    b.ToTable("Products");
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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ProductMeasures");
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

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("ProductSections");
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

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasIndex("HouseId");

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

                    b.HasIndex("ShoppingListId");

                    b.ToTable("ShoppingListProducts");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.User", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<Guid>("HouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("HouseId");

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
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Plan", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.House", "House")
                        .WithMany("Plans")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
