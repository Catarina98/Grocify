namespace GrocifyApp.DAL.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Exceptions
        {
            public const string Generic = "Something went wrong";
            public const string NotFoundException = "Not found";
            public const string EntityDoesNotExist = "The entity does not exist.";
            public const string EmailAlreadyTaken = "This email was already taken.";
        }
        public static class SQLExceptions
        {
            public const string Generic = "An error occured saving changes";
            public const string DuplicateEntityFormat = "{0} already exists.";
            public const string ForeignKeyException = "A conflict with {0} occured.";
        }

        public class ProductSectionNames
        {
            public const string Home = "Home";
            public const string Fishmonger = "Fishmonger";
            public const string Meat = "Meat";
            public const string Sweetgrocery = "Sweet Grocery";
            public const string Saltygrocery = "Salty Grocery";
            public const string FrozenFood = "Frozen food";
            public const string PersonalCare = "Personal Care & Health";
            public const string Bakery = "Bakery";
            public const string Dairy = "Dairy";
            public const string FruitsVegetables = "Fruits and Vegetables";
            public const string Drinks = "Drinks";
            public const string Takeaway = "Takeaway";
        }

        public class ProductSections
        {
            public ProductSectionModel Home = new(new Guid("5dcbf088-2b6e-4d03-845d-8564f2d6b19c"), ProductSectionNames.Home, IconsConsts.ProductSectionIcons.Home);
            public ProductSectionModel Fishmonger = new(new Guid("38f03e29-8b04-4df3-a58b-7a8b5e912a95"), ProductSectionNames.Fishmonger, IconsConsts.ProductSectionIcons.Fishmonger);
            public ProductSectionModel Meat = new(new Guid("72c6b5e5-9c7a-4345-9eb5-6f3a402ef4fd"), ProductSectionNames.Meat, IconsConsts.ProductSectionIcons.Meat);
            public ProductSectionModel Sweetgrocery = new(new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865"), ProductSectionNames.Sweetgrocery, IconsConsts.ProductSectionIcons.Sweetgrocery);
            public ProductSectionModel Saltygrocery = new(new Guid("9a7cf8d1-8b57-4a37-90d5-06e5b4a33a1f"), ProductSectionNames.Saltygrocery, IconsConsts.ProductSectionIcons.Saltygrocery);
            public ProductSectionModel FrozenFood = new(new Guid("ef3705e2-38e6-4ec8-8a06-8e3802d10ec5"), ProductSectionNames.FrozenFood, IconsConsts.ProductSectionIcons.FrozenFood);
            public ProductSectionModel PersonalCare = new(new Guid("76a0cbe1-6d25-40c9-9cf5-430cd7e69d6d"), ProductSectionNames.PersonalCare, IconsConsts.ProductSectionIcons.PersonalCare);
            public ProductSectionModel Bakery = new(new Guid("c44b52e7-19a2-4e4a-8dcb-bbe9cc5bb2e5"), ProductSectionNames.Bakery, IconsConsts.ProductSectionIcons.Bakery);
            public ProductSectionModel Dairy = new(new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"), ProductSectionNames.Dairy, IconsConsts.ProductSectionIcons.Dairy);
            public ProductSectionModel FruitsVegetables = new(new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880"), ProductSectionNames.FruitsVegetables, IconsConsts.ProductSectionIcons.FruitsVegetables);
            public ProductSectionModel Drinks = new(new Guid("8f3a95f1-6b96-43b7-9f62-d3f3db4f0bf1"), ProductSectionNames.Drinks, IconsConsts.ProductSectionIcons.Drinks);
            public ProductSectionModel Takeaway = new(new Guid("a1e9b4cb-946e-4ec5-927d-576c92b5b8f9"), ProductSectionNames.Takeaway, IconsConsts.ProductSectionIcons.Takeaway);
        }

        public class ProductMeasureNames
        {
            public const string Gram = "g";
            public const string Milliliter = "ml";
            public const string Unit = "unit";
            public const string TableSpoon = "tbsp";
        }

        public class ProductMeasures
        {
            public ProductMeasureModel Gram = new(new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"), ProductMeasureNames.Gram);
            public ProductMeasureModel Milliliter = new(new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), ProductMeasureNames.Milliliter);
            public ProductMeasureModel Unit = new(new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"), ProductMeasureNames.Unit);
            public ProductMeasureModel TableSpoon = new(new Guid("f0e88aa9-6d2f-4c88-a3fc-7543647d7ae1"), ProductMeasureNames.TableSpoon);
        }

        public class Products
        {
            public ProductModel Apple = new(new Guid("bd50a227-79db-4a7e-899c-1b0581c5931a"), "Apple", 
                new Guid("d4c7a8c3-729e-4b3d-9247-562a3d8c1e25"), new Guid("a2f1755b-28b0-4b4a-86a1-9fb8c10b4880"));
            public ProductModel Sugar = new(new Guid("452349cd-7cf8-4e52-916f-3fda94eab413"), "Sugar", 
               new Guid("a58e4f12-3f85-4b1f-9b41-6f5967b3d4b1"), new Guid("e0d9c3c1-0d4b-4e08-9dd5-3f2a8059b865"));
            public ProductModel Milk = new(new Guid("37bf06c3-d670-4ea7-9d54-815157f653f7"), "Milk", 
               new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"));
            public ProductModel Egg = new(new Guid("9fca6f9a-ae7b-4cb4-bba0-2d2b4f16e5c2"), "Egg", 
               new Guid("c9b2a381-23f1-4d9a-9e2a-8a0bca31c3a2"), new Guid("18b5b01e-3a0f-4c69-96bf-2ea6c453c865"));
        }

        public class ProductModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Guid MeasureId { get; set; }
            public Guid SectionId { get; set; }

            public ProductModel(Guid id, string name, Guid measureId, Guid sectionId)
            {
                Id = id;
                Name = name;
                MeasureId = measureId;
                SectionId = sectionId;
            }
        }

        public class ProductMeasureModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public ProductMeasureModel(Guid id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class ProductSectionModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }

            public ProductSectionModel(Guid id, string name, string icon)
            {
                Id = id;
                Name = name;
                Icon = icon;
            }
        }
    }
}
