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
    public class HouseController : GenericController<House, HouseRequestModel, HouseResponseModel, BaseSearchModel>
    {
        private readonly IEntitiesService<House> _houseService;

        public HouseController(IEntitiesService<House> houseService, IMapper mapper) : base(houseService, mapper)
        {
            _houseService = houseService;
        }

        [HttpGet("{houseId}")]
        public async Task<ActionResult<List<User>>> GetUsersFromHouse(Guid houseId)
        {
            var getEntity = await _houseService.GetUserByEmail(email);

            if (getEntity == null)
            {
                return NotFound(new { error = GenericConsts.Exceptions.EntityDoesNotExist });
            }

            return Ok(getEntity);
        }
    }
}