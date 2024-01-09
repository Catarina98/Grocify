using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class UserService : EntitiesService<User>, IUserService
    {
        private readonly IUserRepository _uRepository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _uRepository = repository;
        }

        protected override async Task<bool> Validate(User user)
        {
            if (await _uRepository.CheckEmailExists(user.Email, user.Id))
            {
                throw new EmailExistsException(GenericConsts.Exceptions.EmailAlreadyTaken);
            }

            return true;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _uRepository.GetUserByEmail(email);
        }
    }
}
