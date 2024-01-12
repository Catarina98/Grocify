using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> CheckEmailExists(string email, Guid id);
        Task<User?> GetUserByEmail(string email);
    }
}
