using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IShoppingListService : IEntitiesServiceWithHouse<ShoppingList>
    {
        Task<List<ShoppingList>> GetShoppingListsFromHouse(Guid houseId);
        Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null);
    }
}
