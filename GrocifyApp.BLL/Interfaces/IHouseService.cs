using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IHouseService : IEntitiesService<House>
    {
        Task<List<User>> GetUsersFromHouse(Guid houseId);
        Task InsertWithUser(House house, Guid userId, CancellationTokenSource? token = null);
        Task InsertUserToHouse(Guid houseId, Guid userId, CancellationTokenSource? token = null);
        Task DeleteUsersFromHouse(Guid houseId, HashSet<Guid> usersId, bool forceDeleteHouse, CancellationTokenSource? token = null);
    }
}
