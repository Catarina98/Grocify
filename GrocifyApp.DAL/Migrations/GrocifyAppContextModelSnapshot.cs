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
                .HasAnnotation("ProductVersion", "8.0.0")
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

            modelBuilder.Entity("GrocifyApp.DAL.Models.Product", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<Guid>("ProductMeasureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductMeasureId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductMeasure", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.ToTable("ProductMeasures");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductSection", b =>
                {
                    b.HasBaseType("GrocifyApp.DAL.Models.BaseEntity");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.ToTable("ProductSections");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.Product", b =>
                {
                    b.HasOne("GrocifyApp.DAL.Models.ProductMeasure", "ProductMeasure")
                        .WithMany("Products")
                        .HasForeignKey("ProductMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrocifyApp.DAL.Models.ProductSection", "ProductSection")
                        .WithMany("Products")
                        .HasForeignKey("ProductMeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductMeasure");

                    b.Navigation("ProductSection");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductMeasure", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("GrocifyApp.DAL.Models.ProductSection", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
