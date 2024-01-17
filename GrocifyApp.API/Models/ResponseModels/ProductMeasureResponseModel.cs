namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductMeasureResponseModel
    {
        ///<example>Id</example>
        public Guid Id { get; set; } //required?

        /// <example>Meat</example>
        public required string Name { get; set; }

        /// <example>Vegetables Icon</example>
        public required string Icon { get; set; }

        /// <example>HouseId</example>
        public Guid? HouseId { get; set; }
    }
}
