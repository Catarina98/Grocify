using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IShoppingListService : IEntitiesServiceWithHouse<ShoppingList, BaseSearchModelWithHouse<ShoppingList>>
    {
        Task<List<ShoppingListProduct>> GetProductsFromShoppingList(Guid shoppingListId);
        Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null);
        Task ChangeDefaultShoppingList(Guid newDefaultId);
    }
}
