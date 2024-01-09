using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> CheckEmailExists(string Email, Guid Id);
        Task<User?> GetUserByEmail(string Email);
    }
}
