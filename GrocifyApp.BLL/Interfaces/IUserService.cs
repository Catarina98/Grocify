using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IUserService : IEntitiesService<User, BaseSearchModel<User>>
    {
        Task<User?> GetUserByEmail(string Email);
        Task<Guid> GetUserDefaultHouseId(Guid userId);
    }
}
