namespace GrocifyApp.API.Models.ResponseModels
{
    public class UserResponseModel
    {
        /// <example>Id</example>
        public required Guid Id { get; set; }

        /// <example>User Name</example>
        public required string Name { get; set; }

        /// <example>User Email</example>
        public required string Email { get; set; }

        /// <example>Password</example>
        public required string Password { get; set; } = String.Empty; //string.Empty needed?

        /// <example>Confirm password</example>
        public required string ConfirmPassword { get; set; } = String.Empty; //string.Empty needed?
    }
}
