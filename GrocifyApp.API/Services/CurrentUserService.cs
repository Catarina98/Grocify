using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using System.Security.Claims;

namespace GrocifyApp.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IUserService _userService;

        public CurrentUserService(IUserService userService)
        {
            _userService = userService;
        }

        public UserResponseModel? CurrentUser { get; private set; }

        public async Task AuthenticateUser(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null && claimsPrincipal.Identity != null)
            {
                var isAuthenticated = claimsPrincipal.Identity.IsAuthenticated;

                if (isAuthenticated)
                {
                    CurrentUser = await SetCurrentUser(claimsPrincipal);
                }
            }
        }

        private async Task<UserResponseModel> SetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            var emailClaim = claimsPrincipal.FindFirst(ClaimTypes.Email);

            if (emailClaim != null)
            {
                var userEmail = emailClaim.Value;

                var user = await _userService.GetUserByEmail(userEmail) ??
                        throw new InvalidOperationException("Unable to load user.");

                var houseId = await _userService.GetUserDefaultHouseId(user.Id);

                var authUser = new UserResponseModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    AuthenticatedHouseId = houseId,
                    IsDarkMode = user.IsDarkMode
                };

                return authUser;
            }

            throw new InvalidOperationException("Email claim not found.");
        }
    }
}
