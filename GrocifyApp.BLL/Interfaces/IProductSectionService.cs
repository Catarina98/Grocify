using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductSectionService : IEntitiesService<ProductSection>
    {
        Task<List<ProductSection>> GetProductSectionsFromHouse(Guid houseId);
        Task InsertProductSection(ProductSection productSection, CancellationTokenSource? token = null);
    }
}
