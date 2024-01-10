﻿namespace GrocifyApp.API.Data.Consts.ENConsts
{
    public class GenericConsts
    {
        public static class Errors
        {
            public const string EmailAlreadyTaken = "This email was already taken.";
            public const string UserPasswordIncorrect = "User or password are incorrect.";
        }

        public static class RequestModels
        {
            public const string ValidEmail = "Please enter a valid email address.";
            public const string ValidPasswordFormat = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.";
        }
    }
}
