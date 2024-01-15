using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class ProductSectionRepository : Repository<ProductSection>, IProductSectionRepository
    {
        public ProductSectionRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ProductSection>?> GetProductSectionsFromHouse(Guid houseId)
        {
            return await _dbContext.ProductSections
                .Where(ProductSection => ProductSection.HouseId == houseId || ProductSection.HouseId == null)
                .ToListAsync();
        }
    }
}
