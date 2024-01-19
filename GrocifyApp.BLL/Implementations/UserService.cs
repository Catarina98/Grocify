using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class UserService : EntitiesService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }

        protected override async Task<bool> Validate(User user)
        {
            if (await repository.AnyWhere(b => b.Email == user.Email && b.Id != user.Id))
            {
                throw new EmailExistsException();
            }

            return true;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await repository.GetSingleWhere(b => b.Email == email);
        }
    }
}
