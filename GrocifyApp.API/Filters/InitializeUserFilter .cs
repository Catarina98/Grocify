using GrocifyApp.API.Controllers;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace GrocifyApp.API.Filters
{
    public class InitializeUserFilter : IAsyncActionFilter
    {
        private readonly IUserService _userService;

        public InitializeUserFilter(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (AuthController.AuthUser == null)
            {
                var emailClaim = context.HttpContext.User.FindFirst(ClaimTypes.Email);

                if (emailClaim != null)
                {
                    string userEmail = emailClaim.Value;

                    var user = await _userService.GetUserByEmail(userEmail);

                    if (user != null)
                    {
                        var houseId = await _userService.GetUserDefaultHouseId(user.Id);

                        AuthController.AuthUser = new UserResponseModel() { Id = user.Id, Email = user.Email,
                            Name = user.Name, AuthenticatedHouseId = houseId, IsDarkMode = user.IsDarkMode };
                    }
                    else
                    {
                        // User not found, return 401 Unauthorized
                        context.Result = new UnauthorizedResult();

                        return;
                    }
                }
            }

            await next();
        }
    }
}
