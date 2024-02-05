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
            public ProductSectionModel Home = new(ProductSectionNames.Home, IconsConsts.ProductSectionIcons.Home);
            public ProductSectionModel Fishmonger = new(ProductSectionNames.Fishmonger, IconsConsts.ProductSectionIcons.Fishmonger);
            public ProductSectionModel Meat = new(ProductSectionNames.Meat, IconsConsts.ProductSectionIcons.Meat);
            public ProductSectionModel Sweetgrocery = new(ProductSectionNames.Sweetgrocery, IconsConsts.ProductSectionIcons.Sweetgrocery);
            //public ProductSectionModel Saltygrocery = new(ProductSectionNames.Saltygrocery, IconsConsts.ProductSectionIcons.Saltygrocery);
            //public ProductSectionModel FrozenFood = new(ProductSectionNames.FrozenFood, IconsConsts.ProductSectionIcons.FrozenFood);
            //public ProductSectionModel PersonalCare = new(ProductSectionNames.PersonalCare, IconsConsts.ProductSectionIcons.PersonalCare);
            //public ProductSectionModel Bakery = new(ProductSectionNames.Bakery, IconsConsts.ProductSectionIcons.Bakery);
            //public ProductSectionModel Dairy = new(ProductSectionNames.Dairy, IconsConsts.ProductSectionIcons.Dairy);
            public ProductSectionModel FruitsVegetables = new(ProductSectionNames.FruitsVegetables, IconsConsts.ProductSectionIcons.FruitsVegetables);
            //public ProductSectionModel Drinks = new(ProductSectionNames.Drinks, IconsConsts.ProductSectionIcons.Drinks);
            //public ProductSectionModel Takeaway = new(ProductSectionNames.Takeaway, IconsConsts.ProductSectionIcons.Takeaway);
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
            public ProductMeasureModel Gram = new(ProductMeasureNames.Gram);
            public ProductMeasureModel Milliliter = new(ProductMeasureNames.Milliliter);
            public ProductMeasureModel Unit = new(ProductMeasureNames.Unit);
            public ProductMeasureModel TableSpoon = new(ProductMeasureNames.TableSpoon);
        }

        public class Products
        {
            public ProductModel Apple = new("Apple", ProductMeasureNames.Unit, ProductSectionNames.FruitsVegetables);
        }

        public class ProductModel
        {
            public string Name { get; set; }
            public string Measure { get; set; }
            public string Section { get; set; }

            public ProductModel(string name, string measure, string section)
            {
                Name = name;
                Measure = measure;
                Section = section;
            }
        }

        public class ProductMeasureModel
        {
            public string Name { get; set; }

            public ProductMeasureModel(string name)
            {
                Name = name;
            }
        }

        public class ProductSectionModel
        {
            public string Name { get; set; }
            public string Icon { get; set; }

            public ProductSectionModel(string name, string icon)
            {
                Name = name;
                Icon = icon;
            }
        }
    }
}
