using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Implementations;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class HouseService : EntitiesService<House>, IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IRepository<UserHouse> _userHouseRepository;

        public HouseService(IHouseRepository repository, IRepository<UserHouse> userHouseRepository) : base(repository)
        {
            _houseRepository = repository;
            _userHouseRepository = userHouseRepository;
        }

        public async Task<List<User>> GetUsersFromHouse(Guid houseId)
        {
            var users = await _houseRepository.GetUsersFromHouse(houseId);

            if (users == null || users.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoUsersFoundInHouse);
            }

            return users;
        }

        public async Task InsertUserToHouse(Guid houseId, Guid userId, CancellationTokenSource? token = null)
        {
            await _userHouseRepository.Insert(new UserHouse
            {
                UserId = userId,
                HouseId = houseId
            }, token);
        }

        public async Task InsertWithUser(House entity, Guid userId, CancellationTokenSource? token = null)
        {
            await Insert(entity, token);

            await InsertUserToHouse(entity.Id, userId, token);
        }
    }
}
