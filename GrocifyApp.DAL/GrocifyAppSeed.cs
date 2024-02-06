using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static GrocifyApp.DAL.Data.Consts.ENConsts.GenericConsts;

namespace GrocifyApp.DAL
{
    public static class GrocifyAppSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedProductSections(modelBuilder);

            SeedProductMeasures(modelBuilder);

            SeedProducts(modelBuilder);
        }

        private static void SeedProductSections(ModelBuilder modelBuilder)
        {
            ProductSections productSectionsInstance = new ProductSections();

            Type sectionsType = typeof(ProductSections);

            foreach (FieldInfo field in sectionsType.GetFields())
            {
                var p = field.GetValue(productSectionsInstance);

                if (p != null)
                {
                    ProductSectionModel? productSection = (ProductSectionModel)p;

                    var section = new ProductSection
                    {
                        Id = productSection.Id,
                        Name = productSection.Name,
                        Icon = productSection.Icon,
                    };

                    modelBuilder.Entity<ProductSection>().HasData(section);
                }
            }
        }

        private static void SeedProductMeasures(ModelBuilder modelBuilder)
        {
            ProductMeasures productMeasuresInstance = new ProductMeasures();

            Type measuresType = typeof(ProductMeasures);

            foreach (FieldInfo field in measuresType.GetFields())
            {
                var p = field.GetValue(productMeasuresInstance);

                if (p != null)
                {
                    ProductMeasureModel? productMeasure = (ProductMeasureModel)p;

                    var measure = new ProductMeasure
                    {
                        Id = productMeasure.Id,
                        Name = productMeasure.Name
                    };

                    modelBuilder.Entity<ProductMeasure>().HasData(measure);
                }
            }
        }

        private static void SeedProducts(ModelBuilder modelBuilder)
        {
            Products productsInstance = new Products();

            Type productsType = typeof(Products);

            foreach (FieldInfo field in productsType.GetFields())
            {
                var p = field.GetValue(productsInstance);

                if (p != null)
                {
                    ProductModel? product = (ProductModel)p;

                    modelBuilder.Entity<Product>().HasData(
                        new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            ProductMeasureId = product.MeasureId,
                            ProductSectionId = product.SectionId
                        }
                    );
                }
            }
        }
    }
}
