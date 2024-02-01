using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductSectionService : IEntitiesServiceWithHouse<ProductSection>
    {
        Task<List<ProductSection>> GetProductSectionsFromHouse(Guid houseId);
    }
}
