namespace GrocifyApp.API.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Errors
        {
            public const string EmailAlreadyTaken = "This email was already taken.";
            public const string UserPasswordIncorrect = "The email or password you entered is incorrect.";
            public const string UserHasNoHouse = "This user does not have an house. Please contact the administrator.";
            public const string UnableGetEntity = "Unable to get the entity";
            public const string UnableGetAuthenticatedUser = "Unable to get authenticated user";
        }

        public static class RequestModels
        {
            public const string ValidEmail = "Please enter a valid email address.";
            public const string ValidPasswordFormat = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.";
        }

        public static class APIResponses
        {
            public const string EntityCreated = "Entity created successfully";
        }
    }
}
