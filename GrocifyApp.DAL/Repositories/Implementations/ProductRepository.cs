using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Product>?> GetProductsFromHouse(Guid houseId)
        {
            var products = await _dbContext.Products
                .Where(Product => Product.HouseId == houseId || Product.HouseId == null)
                .ToListAsync();

            return products;
        }
    }
}
