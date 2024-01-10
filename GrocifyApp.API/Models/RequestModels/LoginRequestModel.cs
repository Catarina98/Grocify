using GrocifyApp.API.Data.Consts.ENConsts;
using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class LoginRequestModel : BaseEntity
    {
        /// <example>joesmith@gmail.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = GenericConsts.RequestModels.ValidEmail)]
        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
