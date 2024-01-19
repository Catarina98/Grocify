namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Product Name</example>
        public required string Name { get; set; }

        /// <example>ProductMeasureId</example>
        public required Guid ProductMeasureId { get; set; }

        /// <example>ProductSectionId</example>
        public required Guid ProductSectionId { get; set; }

        /// <example>HouseId</example>
        public Guid? HouseId { get; set; }
    }
}
