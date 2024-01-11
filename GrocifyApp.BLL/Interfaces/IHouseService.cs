using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IHouseService : IEntitiesService<House>
    {
        Task<List<User>> GetUsersFromHouse(Guid houseId);
        Task InsertWithUser(House entity, Guid userId, CancellationTokenSource? token = null);
        Task InsertUserToHouse(Guid houseId, Guid userId, CancellationTokenSource? token = null);
    }
}
