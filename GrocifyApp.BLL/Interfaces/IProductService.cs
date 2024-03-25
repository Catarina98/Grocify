using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductService : IEntitiesServiceWithHouse<Product, ProductFilter>
    {
        Task<List<Product>> GetProductsWithSections();
    }
}
