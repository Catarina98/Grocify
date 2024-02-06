using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IShoppingListService : IEntitiesServiceWithHouse<ShoppingList>
    {
        Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null);
        Task<ShoppingList?> GetDefaultShoppingList();
        Task ChangeDefaultShoppingList(ShoppingList newDefault, ShoppingList actualDefault);
    }
}
