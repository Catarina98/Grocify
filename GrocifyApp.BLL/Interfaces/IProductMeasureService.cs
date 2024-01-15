using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IProductMeasureService : IEntitiesService<ProductMeasure>
    {
        Task<List<ProductMeasure>> GetProductMeasuresFromHouse(Guid houseId);
        Task InsertProductMeasure(ProductMeasure productMeasure, CancellationTokenSource? token = null);
    }
}
