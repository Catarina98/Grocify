using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using DALConsts = GrocifyApp.DAL.Data.Consts.ENConsts;

namespace GrocifyApp.API.Controllers
{
    public class UserController : GenericController<User, UserRequestModel, UserResponseModel, BaseSearchModel>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { error = Data.Consts.ENConsts.GenericConsts.Errors.UnableGetEntity });
            }

            var getEntity = await _userService.GetUserByEmail(email);

            if (getEntity == null)
            {
                return NotFound(new { error = DALConsts.GenericConsts.Exceptions.EntityDoesNotExist });
            }

            return Ok(getEntity);
        }

        [HttpPut("toggleDarkMode")]
        public async Task<ActionResult<User>> ToggleDarKMode()
        {
            var currentUser = await _userService.GetUserByEmail(AuthController.AuthUser!.Email);

            if (currentUser == null)
            {
                return NotFound(new { error = DALConsts.GenericConsts.Exceptions.EntityDoesNotExist });
            }
            else
            {
                currentUser.IsDarkMode = !currentUser.IsDarkMode;

                try
                {
                    await _userService.Update(currentUser);
                }
                catch (Exception ex)
                {
                    var errors = new List<string> { ex.Message };

                    return BadRequest(new BadResponseModel { Errors = errors });
                }

                var userResponseModel = _mapper.Map<UserResponseModel>(currentUser);

                return Ok(userResponseModel);
            }
        }
    }
}