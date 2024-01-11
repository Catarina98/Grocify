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
