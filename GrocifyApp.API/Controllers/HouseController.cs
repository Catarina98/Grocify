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
    public class HouseController : GenericController<House, HouseRequestModel, HouseResponseModel, BaseSearchModel>
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService, IMapper mapper) : base(houseService, mapper)
        {
            _houseService = houseService;
        }

        /// <summary>
        /// Get users from house
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">House or users not found!</response>
        /// <response code="400">Unable to get users due to validation error.</response>
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
        public async Task<ActionResult> InsertUserToHouse(Guid houseId, Guid userId)
        {
            try
            {
                await _houseService.InsertUserToHouse(houseId, userId);
            }
            catch (CustomException exception)
            {
                var errors = new List<string> { exception.Message };

                return BadRequest(new BadResponseModel { Errors = errors });
            }
            catch (Exception)
            {
                var errors = new List<string> { GenericConsts.Exceptions.Generic };

                return BadRequest(new BadResponseModel { Errors = errors });
            }

            return Ok();
        }

        /// <summary>
        /// Delete users from house.
        /// </summary>
        /// <response code="201">Users deleted successfully from house.</response>
        /// <response code="400">Unable to delete users due to validation error.</response>
        [HttpDelete("{houseId}/deleteUsers/{forceDeleteHouse}")]
        [HttpDelete("{houseId}/deleteUsers")]
        public async Task<ActionResult> DeleteUsersFromHouse(Guid houseId, [FromBody] HashSet<Guid> usersId, bool forceDeleteHouse = false)
        {
            try
            {
                await _houseService.DeleteUsersFromHouse(houseId, usersId, forceDeleteHouse);
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
                throw new CustomException(APIConsts.GenericConsts.Errors.UnableGetAuthenticatedUser);
            }

            await _houseService.InsertWithUser(entity, AuthController.User.Id);
        }
    }
}