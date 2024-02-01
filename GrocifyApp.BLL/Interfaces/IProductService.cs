using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductService : IEntitiesServiceWithHouse<Product>
    {
        Task<List<Product>> GetProductsFromHouse(Guid houseId);
    }
}
