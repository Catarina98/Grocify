namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductSectionResponseModel
    {
        ///<example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public Guid Id { get; set; } //required?

        /// <example>Product Section Name</example>
        public required string Name { get; set; }

        /// <example>Product Section Icon</example>
        public required string Icon { get; set; }

        /// <example>HouseId</example>
        public Guid? HouseId { get; set; }
    }
}
