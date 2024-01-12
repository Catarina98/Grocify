namespace GrocifyApp.BLL.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Entities
        {
            public const string ProductSection = "Product section";
            public const string ProductMeasure = "Product measure";
        }

        public static class Exceptions
        {
            public const string InsertDuplicateUserInHouse = "This user already exists in this house";
            public const string NoUsersFoundInHouse = "No users found in house";
            public const string NoPrdocutsFoundInHouse = "No products found in house";
            public const string DeleteAllUsersFromHouse = "Delete all users from house will remove the house";
            public const string EntityExistsFormat = "{0} already exists.";
        }
    }
}
