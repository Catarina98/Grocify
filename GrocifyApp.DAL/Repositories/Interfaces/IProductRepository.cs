using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>?> GetProductsFromHouse(Guid houseId);
    }
}
