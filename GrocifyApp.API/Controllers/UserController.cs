using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : GenericController<User, UserRequestModel, UserResponseModel, BaseSearchModel>
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest(new { error = Data.Consts.ENConsts.GenericConsts.Errors.UnableGetEntity });
            }

            var getEntity = await _userService.GetUserByEmail(email);

            if (getEntity == null)
            {
                return NotFound(new { error = GenericConsts.Exceptions.EntityDoesNotExist });
            }

            return Ok(getEntity);
        }
    }
}