using GrocifyApp.API.Models.ResponseModels;
using System.Security.Claims;

namespace GrocifyApp.API.Services
{
    public interface ICurrentUserService
    {
        public UserResponseModel? CurrentUser { get; }
        public Task AuthenticateUser(ClaimsPrincipal claimsPrincipal);
    }
}
