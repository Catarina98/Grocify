using GrocifyApp.API.Data.Consts.ENConsts;
using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GrocifyApp.API.Models.RequestModels
{
    public class UserRequestModel
    {
        /// <example>Joe Smith</example>
        public required string Name { get; set; }

        /// <example>email@outlook.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = GenericConsts.RequestModels.ValidEmail)]
        public required string Email { get; set; }

        /// <example>FbjYxLWIlgcQn8sX6KijffST</example>
        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = GenericConsts.RequestModels.ValidPasswordFormat)]
        public required string Password { get; set; }

        /// <example>FbjYxLWIlgcQn8sX6KijffST</example>
        [StringLength(24, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = GenericConsts.RequestModels.ValidPasswordFormat)]
        public string ConfirmPassword { get; set; } = String.Empty; //i cant make this required because of line 84 of AuthController

        [JsonIgnore]
        public byte[]? PasswordHash { get; set; }
        [JsonIgnore]
        public byte[]? PasswordSalt { get; set; }
    }
}
