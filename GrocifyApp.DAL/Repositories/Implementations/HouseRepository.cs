using GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(GrocifyAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckEmailExists(string email, Guid id)
        {
            return await _dbContext.Users
                    .AnyAsync(b => b.Email == email && b.Id != id);
        }

        public async Task<User?> GetUserByEmail(string email)
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

            return user;
        }

        public async Task<List<User>?> GetUsersFromHouse(Guid houseId)
        {
            var users = await _dbContext.UserHouses
                .Where(userHouse => userHouse.HouseId == houseId)
                .Select(userHouse => userHouse.User!)
                .ToListAsync();

            return users;
        }
    }
}
