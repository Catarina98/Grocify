using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class UserRequestModel : BaseEntity
    {
        /// <example>Joe Smith</example>
        public required string Name { get; set; }

        /// <example>email@outlook.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid email address.")] //const??
        public required string Email { get; set; }

        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.")] //const??
        public required string Password { get; set; }

        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.")] //const??
        public string ConfirmPassword { get; set; } = String.Empty; //i cant make this required because of line 84 of AuthController

        public required byte[] PasswordHash { get; set; }

        public required byte[] PasswordSalt { get; set; }
    }
}
