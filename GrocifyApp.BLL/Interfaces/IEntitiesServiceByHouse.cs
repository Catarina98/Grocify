using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesServiceByHouse<T> where T : BaseEntityWithHouse
    {
        public Guid HouseId { get; set; }
        Task<T?> Get(Guid id, Guid houseId);
        Task<IEnumerable<T>> GetAll(Guid houseId, CancellationTokenSource? token = null);
    }
}
