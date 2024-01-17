namespace GrocifyApp.API.Models.ResponseModels
{
    public class ShoppingListProductResponseModel
    {
        /// <example>Id</example>
        public required Guid Id { get; set; }

        /// <example>Quantity</example>
        public required int Quantity { get; set; }

        /// <example>ProductId</example>
        public required Guid ProductId { get; set; }
    }
}
