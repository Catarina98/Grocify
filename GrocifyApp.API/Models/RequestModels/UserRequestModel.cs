using GrocifyApp.API.Data.Consts.ENConsts;
using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class UserRequestModel : BaseEntity
    {
        /// <example>Joe Smith</example>
        public required string Name { get; set; }

        /// <example>email@outlook.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = GenericConsts.RequestModels.ValidEmail)]
        public required string Email { get; set; }

        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = GenericConsts.RequestModels.ValidPasswordFormat)]
        public required string Password { get; set; }

        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = GenericConsts.RequestModels.ValidPasswordFormat)]
        public string ConfirmPassword { get; set; } = String.Empty; //i cant make this required because of line 84 of AuthController

        public required byte[] PasswordHash { get; set; }

        public required byte[] PasswordSalt { get; set; }
    }
}
