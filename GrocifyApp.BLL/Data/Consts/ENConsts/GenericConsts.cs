namespace GrocifyApp.BLL.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Entities
        {
            public const string ProductSection = "Product section";
            public const string ProductMeasure = "Product measure";
            public const string Product = "Product";
            public const string Entity = "Entity";
        }

        public static class Exceptions
        {
            public const string InsertDuplicateUserInHouse = "This user already exists in this house";
            public const string NoUsersFoundInHouse = "No users found in house";
            public const string NoProductsFoundInHouse = "No products found in house";
            public const string NoSectionsFoundInHouse = "No sections found in house";
            public const string NoMeasuresFoundInHouse = "No measures found in house";
            public const string HouseCannotBeNull = "House cannot be null";
            public const string DeleteAllUsersFromHouse = "Delete all users from house will remove the house";
            public const string DuplicateEntityFormat = "{0} already exists.";
        }
    }
}
