using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductSectionRequestModel
    {
        /// <example>Meat</example>
        public required string Name { get; set; }

        /// <example>Chicken Icon</example>
        public required string Icon { get; set; }
    }
}
