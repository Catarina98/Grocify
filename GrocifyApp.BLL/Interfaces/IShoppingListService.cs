using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IShoppingListService : IEntitiesServiceWithHouse<ShoppingList>
    {
        Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null);
        Task ChangeDefaultShoppingList(Guid newDefaultId);
    }
}
