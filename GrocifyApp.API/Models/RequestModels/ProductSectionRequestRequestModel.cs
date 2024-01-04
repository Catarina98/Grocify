using System.ComponentModel.DataAnnotations;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductSectionRequestRequestModel : BaseEntity
    {
        /// <example>Meat</example>
        [Required]
        public required string Name { get; set; }
        /// <example>Chicken Icon</example>
        [Required]
        public required string Icon { get; set; }
    }
}
