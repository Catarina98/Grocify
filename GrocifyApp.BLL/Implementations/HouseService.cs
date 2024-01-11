﻿using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
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

        public async Task InsertWithUser(House house, Guid userId, CancellationTokenSource? token = null)
        {
            await Insert(house, token);

            await InsertUserToHouse(house.Id, userId, token);
        }
    }
}
