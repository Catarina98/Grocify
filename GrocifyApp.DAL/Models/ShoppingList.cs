namespace GrocifyApp.DAL.Models
{
    public class ShoppingList : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public required bool DefaultList { get; set; }
        public ICollection<ShoppingListProduct>? ShoppingListProducts { get; set; }
    }
}
