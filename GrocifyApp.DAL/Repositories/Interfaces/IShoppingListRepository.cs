using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IShoppingListRepository : IRepository<ShoppingList>
    {
        Task<List<ShoppingList>?> GetShoppingListsFromHouse(Guid houseId);
        Task<bool> AnyShoppingListInHouse(Guid houseId);
    }
}
