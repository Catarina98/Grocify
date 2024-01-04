namespace GrocifyApp.DAL.Models
{
    public class ShoppingListProduct : BaseEntity
    {
        public required int Quantity { get; set; }
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required Guid ShoppingListId { get; set; }
        public ShoppingList? ShoppingList { get; set; }
    }
}
