using AutoMapper;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GenericControllerWithHouse<TEntity, TRequestModel, TResponseModel, TFilter>
    : GenericControllerBase<TEntity, TRequestModel, TResponseModel, TFilter, IEntitiesServiceWithHouse<TEntity>>
    where TEntity : BaseEntityWithHouse
    where TRequestModel : class
    where TResponseModel : class
    where TFilter : BaseSearchModel
    {
        public GenericControllerWithHouse(IEntitiesServiceWithHouse<TEntity> genericBusiness, IMapper mapper) : base(genericBusiness, mapper)
        {
            genericBusiness.HouseId = AuthController.User?.AuthenticatedHouseId;
        }
    }

}