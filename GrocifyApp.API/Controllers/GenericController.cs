using AutoMapper;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GenericController<TEntity, TRequestModel, TResponseModel, TFilter> : ControllerBase where TEntity : BaseEntity where TRequestModel : BaseEntity where TResponseModel : class where TFilter : BaseSearchModel
    {
        private readonly IEntitiesService<TEntity> _genericBusiness;
        private readonly IMapper _mapper;
        private readonly ILogger<GenericController<TEntity, TRequestModel, TResponseModel, TFilter>> _logger;

        public GenericController(IEntitiesService<TEntity> genericBusiness, IMapper mapper, ILogger<GenericController<TEntity, TRequestModel, TResponseModel, TFilter>> logger)
        {
            _genericBusiness = genericBusiness;
            _mapper = mapper;
            _logger = logger;
        }

        //GET ENTITY BY ID
        /// <summary>
        /// Gets a specific entity by id.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">Entity not found!</response>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TResponseModel>> Get(Guid id)
        {
            var getEntity = await _genericBusiness.Get(id);

            if (getEntity == null)
            {
                return NotFound(new { error = "The entity does not exist" });
            }

            return Ok(getEntity);
        }

        //GET ALL ENTITIES
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <response code="200">Success.</response>
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _genericBusiness.GetAll();
            return Ok(entities);
        }

        //CREATE Entity
        /// <summary>
        /// Creates a entity.
        /// </summary>
        /// <response code="201">Entity created successfully.</response>
        /// <response code="400">Unable to create the entity due to validation error.</response>
        [HttpPost]
        public virtual async Task<ActionResult<TResponseModel>> Insert([FromBody] TRequestModel entity)
        {
            if (entity == null || !ModelState.IsValid)
            {
                return BadRequest(new BadRequestModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            var u = _mapper.Map<TEntity>(entity);

            try
            {
                await _genericBusiness.Insert(u);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return BadRequest(new BadRequestModel { Errors = errors });
            }

            return Created("Entity created successfully", entity);
        }

        //UPDATE ENTITY BY ID
        /// <summary>
        /// Updates a specific entity by id.
        /// </summary>
        /// <response code="201">Entity updated successfully.</response>
        /// <response code="400">Unable to update the entity due to validation error.</response>
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TResponseModel>> Update(Guid id, [FromBody] TRequestModel entity)
        {
            if (entity == null || !ModelState.IsValid)
            {
                return BadRequest(new BadRequestModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            entity.Id = id;

            var u = _mapper.Map<TEntity>(entity);
            u.Id = id;

            if (u == null)
            {
                return NotFound(new { error = "The entity does not exist" });
            }

            try
            {
                await _genericBusiness.Update(u);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return BadRequest(new BadRequestModel { Errors = errors });
            }

            return Ok();

        }
    }
}