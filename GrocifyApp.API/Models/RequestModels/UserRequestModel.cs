using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class UserRequestModel : BaseEntity
    {
        /// <example>Joe Smith</example>
        public required string Name { get; set; }

        /// <example>email@outlook.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid email address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")] //auth
        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.")]
        public string Password { get; set; } = String.Empty;

        [Required(ErrorMessage = "Confirm password is required.")] //auth
        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Passwords must contains at least 8 characters and contain at least one uppercase letter and numbers.")]
        public string ConfirmPassword { get; set; } = String.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
