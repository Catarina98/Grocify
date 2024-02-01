using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductMeasureService : IEntitiesServiceWithHouse<ProductMeasure>
    {
        Task<List<ProductMeasure>> GetProductMeasuresFromHouse(Guid houseId);
    }
}
