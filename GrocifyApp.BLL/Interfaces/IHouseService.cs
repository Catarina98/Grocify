using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IHouseService : IEntitiesService<House>
    {
        Task<List<User>> GetUsersFromHouse(Guid houseId);
    }
}
