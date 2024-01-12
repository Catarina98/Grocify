using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductService : IEntitiesService<Product>
    {
        Task<List<Product>> GetProductsFromHouse(Guid houseId);
        Task InsertProduct(Product product, CancellationTokenSource? token = null);
    }
}
