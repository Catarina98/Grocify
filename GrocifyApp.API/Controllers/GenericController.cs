using AutoMapper;
using GrocifyApp.API.Services;
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
    public class GenericController<TEntity, TRequestModel, TResponseModel, TFilter>(IEntitiesService<TEntity> genericBusiness, IMapper mapper, ICurrentUserService currentUserService)
    : GenericControllerBase<TEntity, TRequestModel, TResponseModel, TFilter, IEntitiesService<TEntity>>(genericBusiness, mapper, currentUserService)
    where TEntity : BaseEntity
    where TRequestModel : class
    where TResponseModel : class
    where TFilter : BaseSearchModel
    {
    }

}