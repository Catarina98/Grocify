using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IInventoryService : IEntitiesServiceWithHouse<Inventory, BaseSearchModelWithHouse<Inventory>>
    {
        Task AddProductsToInventory(Guid id, Dictionary<Guid, InventoryProduct> inventoryProducts, CancellationTokenSource? token = null);
        Task ChangeDefaultInventory(Guid newDefaultId);
    }
}
