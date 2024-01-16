using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class ProductMeasureRepository : Repository<ProductMeasure>, IProductMeasureRepository
    {
        public ProductMeasureRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProductMeasure>?> GetProductMeasuresFromHouse(Guid houseId)
        {
            return await _dbContext.ProductMeasures
                .Where(ProductMeasure => ProductMeasure.HouseId == houseId || ProductMeasure.HouseId == null)
                .ToListAsync();
        }

        public async Task<bool> CheckMeasureExistsInHouse(Guid houseId, string name)
        {
            return await _dbContext.ProductMeasures
                .AnyAsync(ProductMeasure => (ProductMeasure.HouseId == houseId || ProductMeasure.HouseId == null) && ProductMeasure.Name == name);
        }
    }
}
