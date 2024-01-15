using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IProductMeasureRepository : IRepository<ProductMeasure>
    {
        Task<List<ProductMeasure>?> GetProductMeasuresFromHouse(Guid houseId);
        Task<bool> CheckMeasureExistsInHouse(Guid houseId, string name);
    }
}
