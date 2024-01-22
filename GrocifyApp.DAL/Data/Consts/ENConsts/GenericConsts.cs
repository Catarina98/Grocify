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
    }
}
