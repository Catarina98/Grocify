using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class ShoppingListProductRepository : Repository<ShoppingListProduct>, IShoppingListProductRepository
    {
        public ShoppingListProductRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        //public async Task<bool> IncrementQuantityOfProduct(Guid shoppingId, Guid productId, int quantity)
        //{
        //    return await _dbContext.ShoppingListProducts
        //        .AnyAsync(ShoppingListProduct => ShoppingListProduct.ShoppingListId == shoppingId && ShoppingListProduct.ProductId == productId);
        //}
        //public async Task<bool> CheckProductExistInList(Guid shoppingId, Guid productId)
        //{
        //    return await _dbContext.ShoppingListProducts
        //        .AnyAsync(ShoppingListProduct => ShoppingListProduct.ShoppingListId == shoppingId && ShoppingListProduct.ProductId == productId);
        //}
        public async Task<ShoppingListProduct?> CheckProductExistInList(Guid shoppingId, Guid productId)
        {
            return await _dbContext.ShoppingListProducts
                .FirstOrDefaultAsync(ShoppingListProduct => ShoppingListProduct.ShoppingListId == shoppingId && ShoppingListProduct.ProductId == productId);
        }
    }
}