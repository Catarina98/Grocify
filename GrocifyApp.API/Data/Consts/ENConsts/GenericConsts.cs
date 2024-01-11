namespace GrocifyApp.API.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Errors
        {
            public const string EmailAlreadyTaken = "This email was already taken.";
            public const string UserPasswordIncorrect = "User or password are incorrect.";
            public const string UnableGetEntity = "Unable to get the entity";
            public const string UnableGetUser = "Unable to get authenticated user";
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
