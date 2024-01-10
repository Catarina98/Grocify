using GrocifyApp.API.Data.Consts.ENConsts;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class LoginRequestModel
    {
        /// <example>email@outlook.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = GenericConsts.RequestModels.ValidEmail)]
        public required string Email { get; set; }

        /// <example>FbjYxLWIlgcQn8sX6KijffST</example>
        public required string Password { get; set; } = String.Empty; //string.Empty needed?
    }
}
