namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductMeasureResponseModel
    {
        ///<example>Id</example>
        public required Guid Id { get; set; }

        /// <example>Product Measure Name</example>
        public required string Name { get; set; }

        /// <example>HouseId</example>
        public Guid? HouseId { get; set; }
    }
}
