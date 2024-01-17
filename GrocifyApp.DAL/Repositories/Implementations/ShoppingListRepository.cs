using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class ShoppingListRepository : Repository<ShoppingList>, IShoppingListRepository
    {
        public ShoppingListRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ShoppingList>?> GetShoppingListsFromHouse(Guid houseId)
        {
            return await _dbContext.ShoppingLists
                .Where(ShoppingList => ShoppingList.HouseId == houseId)
                .ToListAsync();
        }

        public async Task<bool> AnyShoppingListInHouse(Guid houseId)
        {
            return await _dbContext.ShoppingLists
                .AnyAsync(ShoppingList => ShoppingList.HouseId == houseId);
        }
    }
}
