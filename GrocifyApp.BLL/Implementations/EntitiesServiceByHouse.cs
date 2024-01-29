using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class EntitiesServiceByHouse<T> : EntitiesService<T>, IEntitiesServiceByHouse<T> where T : BaseEntityWithHouse
    {
        public EntitiesServiceByHouse(IRepository<T> repository) : base(repository)
        {
        }

        public Guid HouseId { get; set; }

        public async Task<T?> Get(Guid id, Guid houseId)
        {
            return await repository.GetSingleWhere(x => x.Id == id && x.HouseId == houseId);
        }

        public async Task<IEnumerable<T>> GetAll(Guid houseId, CancellationTokenSource? token = null)
        {
            return await repository.GetWhere(x => x.HouseId == houseId || x.HouseId == null);
        }
    }

}
