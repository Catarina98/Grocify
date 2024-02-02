using GrocifyApp.API.Models.ResponseModels;
using System.Security.Claims;

namespace GrocifyApp.API.Services
{
    public interface ICurrentUserService
    {
        UserResponseModel? CurrentUser { get; }
        Task AuthenticateUser(ClaimsPrincipal claimsPrincipal);
    }
}
