using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class UserService : EntitiesService<User>
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
                throw new EmailExistsException();
            }

            return true;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _uRepository.GetUserByEmail(email);
        }
    }
}
