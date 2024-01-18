using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IShoppingListProductRepository : IRepository<ShoppingListProduct>
    {
        Task<ShoppingListProduct?> CheckProductExistInList(Guid shoppingListId, Guid productId);
    }
}