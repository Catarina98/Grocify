using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static GrocifyApp.DAL.Data.Consts.ENConsts.GenericConsts;
using static GrocifyApp.DAL.Data.Consts.IconsConsts;

namespace GrocifyApp.DAL
{
    public static class GrocifyAppSeed
    {
        public static Dictionary<string, Guid> ProductSections = new Dictionary<string, Guid>();
        public static Dictionary<string, Guid> ProductMeasures = new Dictionary<string, Guid>();

        public static Guid[] Guids =
        {
            new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"),
            new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"),
            new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"),
            new Guid("f0e88aa9-6d2f-4c88-a3fc-7543647d7ae1"),
            new Guid("bd50a227-79db-4a7e-899c-1b0581c5931a"),
            new Guid("5dcbf088-2b6e-4d03-845d-8564f2d6b19c"),
            new Guid("38f03e29-8b04-4df3-a58b-7a8b5e912a95"),
            new Guid("72c6b5e5-9c7a-4345-9eb5-6f3a402ef4fd"),
            new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865"),
            new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880"),
            new Guid("9a7cf8d1-8b57-4a37-90d5-06e5b4a33a1f"),
            new Guid("ef3705e2-38e6-4ec8-8a06-8e3802d10ec5"),
            new Guid("76a0cbe1-6d25-40c9-9cf5-430cd7e69d6d"),
            new Guid("c44b52e7-19a2-4e4a-8dcb-bbe9cc5bb2e5"),
            new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"),
            new Guid("8f3a95f1-6b96-43b7-9f62-d3f3db4f0bf1"),
            new Guid("a1e9b4cb-946e-4ec5-927d-576c92b5b8f9"),
            new Guid("452349cd-7cf8-4e52-916f-3fda94eab413"),
            new Guid("37bf06c3-d670-4ea7-9d54-815157f653f7"),
            new Guid("9fca6f9a-ae7b-4cb4-bba0-2d2b4f16e5c2")
        };

        private static int currentGuidIndex = 0;


        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedProductSections(modelBuilder);

            SeedProductMeasures(modelBuilder);

            SeedProducts(modelBuilder);
        }

        private static void SeedProductSections(ModelBuilder modelBuilder)
        {
            try
            {
                Type sectionNamesType = typeof(ProductSectionNames);

                Type sectionIconsType = typeof(ProductSectionIcons);

                foreach (FieldInfo field in sectionNamesType.GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    string? sectionName = field.GetValue(null)?.ToString();

                    string? iconName = sectionIconsType.GetField(field.Name)?.GetValue(null)?.ToString();

                    if (!string.IsNullOrEmpty(sectionName) && !string.IsNullOrEmpty(iconName))
                    {
                        if (!ProductSections.ContainsKey(sectionName))
                        {
                            var productSection =
                                new ProductSection
                                {
                                    Id = Guids[currentGuidIndex],
                                    HouseId = null,
                                    IsDeleted = false,
                                    Name = sectionName,
                                    Icon = iconName
                                };

                            modelBuilder.Entity<ProductSection>().HasData(productSection);

                            Console.WriteLine(productSection.Id);

                            ProductSections.Add(sectionName, Guids[currentGuidIndex]);

                            currentGuidIndex++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void SeedProductMeasures(ModelBuilder modelBuilder)
        {
            Type measureTypes = typeof(ProductMeasureNames);

            foreach (FieldInfo field in measureTypes.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string? measureName = field.GetValue(null)?.ToString();

                if (!string.IsNullOrEmpty(measureName))
                {
                    if (!ProductMeasures.ContainsKey(measureName))
                    {
                        Guid id = Guids[currentGuidIndex];

                        modelBuilder.Entity<ProductMeasure>().HasData(
                            new ProductMeasure { Id = id, Name = measureName }
                        );
                        Console.WriteLine(id);

                        ProductMeasures.Add(measureName, id);

                        currentGuidIndex++;
                    }
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
                            Id = Guids[currentGuidIndex],
                            Name = product.Name,
                            ProductMeasureId = ProductMeasures[product.Measure],
                            ProductSectionId = ProductSections[product.Section]
                        }
                    );
                    Console.WriteLine(Guids[currentGuidIndex]);

                    currentGuidIndex++;
                }
            }
        }
    }
}
