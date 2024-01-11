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
using static GrocifyApp.API.Data.Consts.ENConsts.GenericConsts;
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

        /// <summary>
        /// Insert user to house.
        /// </summary>
        /// <response code="201">User inserted successfully.</response>
        /// <response code="400">Unable to insert user due to validation error.</response>
        [HttpPut("{houseId}/user/{userId}")]
        public virtual async Task<ActionResult> Insert(Guid houseId, Guid userId)
        {
            try
            {
                await _houseService.InsertUserToHouse(houseId, userId);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };

                return BadRequest(new BadResponseModel { Errors = errors });
            }

            return Ok();
        }

        /// <summary>
        /// Delete users from house.
        /// </summary>
        /// <response code="201">Users deleted successfully from house.</response>
        /// <response code="400">Unable to delete users due to validation error.</response>
        [HttpDelete("{houseId}/deleteUsers/{forceDelete}")]
        [HttpDelete("{houseId}/deleteUsers")]
        public virtual async Task<ActionResult> DeleteUsersFromHouse(Guid houseId, [FromBody] HashSet<Guid> usersId, bool forceDelete = false)
        {
            try
            {
                await _houseService.DeleteUsersFromHouse(houseId, usersId, forceDelete);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };

                return BadRequest(new BadResponseModel { Errors = errors });
            }

            return Ok();
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