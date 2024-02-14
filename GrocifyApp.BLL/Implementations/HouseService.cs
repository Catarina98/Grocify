using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class HouseService : EntitiesService<House, BaseSearchModel<House>>, IHouseService
    {
        private readonly IRepository<UserHouse> _userHouseRepository;

        public HouseService(IRepository<House> houseRepository, IRepository<UserHouse> userHouseRepository) : base(houseRepository)
        {
            _userHouseRepository = userHouseRepository;
        }

        public async Task DeleteUsersFromHouse(Guid houseId, HashSet<Guid> usersId, bool forceDeleteHouse, CancellationTokenSource? token = null)
        {
            if (!forceDeleteHouse)
            {
                var houseUsers = await GetUsersFromHouse(houseId);
                
                if(usersId.Count >= houseUsers.Count && usersId.SetEquals(houseUsers.Select(x => x.Id)))
                {
                    throw new CustomException(GenericConsts.Exceptions.DeleteAllUsersFromHouse);
                }
            }

            await _userHouseRepository.DeleteMultipleLeafType(x => x.HouseId == houseId && usersId.Contains(x.UserId), token);

            if (forceDeleteHouse)
            {
                try
                {
                    var houseUsers = await GetUsersFromHouse(houseId);
                }
                catch(NotFoundException)
                {
                    await DeleteById(houseId, token);
                }
            }
        }

        public async Task<List<User>> GetUsersFromHouse(Guid houseId)
        {
            var users = await _userHouseRepository.GetWhere<User>(userHouse => userHouse.HouseId == houseId, userHouse => userHouse.User!);

            if (users == null || users.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoUsersFoundInHouse);
            }

            return users;
        }


        /// <summary>
        /// If the user doesn't have any house yet, when you add a new one, it will automatically become the default house for that user
        /// </summary>
        public async Task InsertUserToHouse(Guid houseId, Guid userId, CancellationTokenSource? token = null)
        {
            try
            {
                var newUserHouse = new UserHouse
                {
                    UserId = userId,
                    HouseId = houseId
                };

                if (!await _userHouseRepository.AnyWhere(x => x.UserId == userId))
                {
                    newUserHouse.DefaultHouse = true;
                }

                await _userHouseRepository.Insert(newUserHouse, token);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                throw new SQLException(ex, GenericConsts.Exceptions.InsertDuplicateUserInHouse);
            }
        }

        public async Task InsertWithUser(House house, Guid userId, CancellationTokenSource? token = null)
        {
            if(await _userHouseRepository.AnyWhere(x => x.UserId == userId && x.House != null && x.House.Name == house.Name))
            {
                throw new SQLException(SQLException.SQLExceptionType.DuplicateEntity, GenericConsts.Exceptions.DuplicateHouseName);
            }

            await Insert(house, token);

            await InsertUserToHouse(house.Id, userId, token);
        }
    }
}
