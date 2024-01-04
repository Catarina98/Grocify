using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductSectionRequestRequestModel
    {
        /// <example>Meat</example>
        [Required]
        public required string Name { get; set; }
        /// <example>Chicken Icon</example>
        [Required]
        public required string Icon { get; set; }
    }
}
