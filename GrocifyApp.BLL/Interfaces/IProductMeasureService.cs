using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductMeasureService : IEntitiesService<ProductMeasure>
    {
        Task<List<ProductMeasure>> GetProductMeasuresFromHouse(Guid houseId);
    }
}
