using _1.MiniShop.API.Controllers;
using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using APIConsts = GrocifyApp.API.Data.Consts.ENConsts;

namespace GrocifyApp.API.Controllers
{
    [Route("api/[controller]")]
    public class HouseController : GenericController<House, HouseRequestModel, HouseResponseModel, BaseSearchModel>
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService, IMapper mapper) : base(houseService, mapper)
        {
            _houseService = houseService;
        }

        [HttpGet("{id}/users")]
        public async Task<ActionResult<List<User>>> GetUsersFromHouse(Guid id)
        {
            try
            {
                var users = await _houseService.GetUsersFromHouse(id);

                return Ok(users);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception)
            {
                return BadRequest(new { error = GenericConsts.Exceptions.Generic });
            }
        }

        protected override async Task InsertAction(House entity)
        {
            if (AuthController.User == null)
            {
                throw new CustomException(APIConsts.GenericConsts.Errors.UnableGetUser);
            }

            await _houseService.InsertWithUser(entity, AuthController.User.Id);
        }
    }
}