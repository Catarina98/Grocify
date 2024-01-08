using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckEmailExists(string email, Guid id)
        {
            return await _dbContext.Users
                    .AnyAsync(b => b.Email == email && b.Id != id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            User? user = null;

            try
            {
                user = await _dbContext.Users.SingleAsync(b => b.Email == email);
            }

            catch
            {
                user = null;
            }

            return user; //Possible null reference return
        }
    }
}
