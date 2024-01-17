namespace GrocifyApp.API.Models.ResponseModels
{
    public class ShoppingListResponseModel
    {
        /// <example>Id</example>
        public required Guid Id { get; set; }

        /// <example>Shopping List Name</example>
        public required string Name { get; set; }

        /// <example>DefaultList</example>
        public required bool DefaultList { get; set; }

        /// <example>HouseId</example>
        public required Guid HouseId { get; set; }
    }
}
