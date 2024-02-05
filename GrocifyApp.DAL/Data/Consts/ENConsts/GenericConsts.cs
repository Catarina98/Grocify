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

        public class ProductMeasureNames
        {
            public const string Gram = "g";
            public const string Milliliter = "ml";
            public const string Unit = "unit";
            public const string TableSpoon = "tbsp";
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
    }
}
