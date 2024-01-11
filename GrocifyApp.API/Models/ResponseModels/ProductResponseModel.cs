namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductResponseModel
    {
        /// <example>Id</example>
        public required Guid Id { get; set; }

        /// <example>ProductMeasureId</example>
        public required Guid ProductMeasureId { get; set; }

        /// <example>ProductSectionId</example>
        public required Guid ProductSectionId { get; set; }

        /// <example>HouseId</example>
        public Guid? HouseId { get; set; }
    }
}
