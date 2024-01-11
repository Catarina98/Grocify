using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<List<User>?> GetUsersFromHouse(Guid houseId);
    }
}
