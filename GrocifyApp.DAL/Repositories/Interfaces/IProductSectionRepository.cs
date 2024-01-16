using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IProductSectionRepository : IRepository<ProductSection>
    {
        Task<List<ProductSection>?> GetProductSectionsFromHouse(Guid houseId);
        Task<bool> CheckSectionExistsInHouse(Guid houseId, string name);
    }
}
