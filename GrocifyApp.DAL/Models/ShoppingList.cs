namespace GrocifyApp.DAL.Models
{
    public class ShoppingList : BaseEntity
    {
        public required string Name { get; set; }
        public required bool DefaultList { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
        public ICollection<ShoppingListProduct>? ShoppingListProducts { get; set; }
    }
}
