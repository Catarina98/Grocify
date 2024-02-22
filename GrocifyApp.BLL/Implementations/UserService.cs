using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class UserService : EntitiesService<User, BaseSearchModel<User>>, IUserService
    {
        private readonly IRepository<UserHouse> _userHouseRepository;
        private readonly IHouseService _houseService;

        public UserService(IRepository<User> repository, IRepository<UserHouse> userHouseRepository,
            IHouseService houseService) : base(repository)
        {
            _userHouseRepository = userHouseRepository;

            _houseService = houseService;
        }

        protected override async Task<bool> Validate(User user)
        {
            if (await repository.AnyWhere(b => b.Email == user.Email && b.Id != user.Id))
            {
                throw new EmailExistsException();
            }

            return true;
        }

        protected override async Task FinishInsert(User entity)
        {
            House house = new House()
            {
                Name = "My House"
            };

            await _houseService.InsertWithUser(house, entity.Id);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await repository.GetSingleWhere(b => b.Email == email);
        }

        public async Task<Guid> GetUserDefaultHouseId(Guid userId)
        {
            Guid? userHouseId = await _userHouseRepository.GetSingleWhere
                (userHouse => userHouse.UserId == userId && userHouse.DefaultHouse == true, userHouse => userHouse.HouseId);

            if (userHouseId == null)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoHouseFoundForUser);
            }

            return userHouseId.Value;
        }
    }
}
