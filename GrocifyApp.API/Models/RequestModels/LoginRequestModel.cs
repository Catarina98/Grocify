using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class LoginRequestModel : BaseEntity
    {
        /// <example>joesmith@gmail.com</example>
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")] //auth
        public string Password { get; set; } = String.Empty;
    }
}
