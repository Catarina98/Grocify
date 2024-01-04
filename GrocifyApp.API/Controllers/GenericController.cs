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
    public class GenericController<TEntity, TRequestModel, TResponseModel, TFilter>(
        IEntitiesService<TEntity> genericBusiness,
        IMapper mapper) : ControllerBase
        where TEntity : BaseEntity
        where TRequestModel : class
        where TResponseModel : class
        where TFilter : BaseSearchModel
    {
        //GET ENTITY BY ID
        /// <summary>
        /// Gets a specific entity by id.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">Entity not found!</response>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TResponseModel>> Get(Guid id)
        {
            var getEntity = await genericBusiness.Get(id);

            if (getEntity == null)
            {
                return NotFound(new { error = "The entity does not exist" });
            }
            
            var response = mapper.Map<TResponseModel>(getEntity);

            return Ok(response);
        }

        //GET ALL ENTITIES
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <response code="200">Success.</response>
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var entities = await genericBusiness.GetAll();
            
            return Ok(entities);
        }

        //CREATE ENTITY
        /// <summary>
        /// Creates a entity.
        /// </summary>
        /// <response code="201">Entity created successfully.</response>
        /// <response code="400">Unable to create the entity due to validation error.</response>
        [HttpPost]
        public virtual async Task<ActionResult<TResponseModel>> Insert([FromBody] TRequestModel entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            var u = mapper.Map<TEntity>(entity);

            try
            {
                await genericBusiness.Insert(u);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };

                return BadRequest(new BadRequestModel { Errors = errors });
            }
            
            var response = mapper.Map<TResponseModel>(entity);

            return Created("Entity created successfully", response);
        }

        //UPDATE ENTITY BY ID
        /// <summary>
        /// Updates a specific entity by id.
        /// </summary>
        /// <response code="201">Entity updated successfully.</response>
        /// <response code="400">Unable to update the entity due to validation error.</response>
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Update(Guid id, [FromBody] TRequestModel entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            var u = mapper.Map<TEntity>(entity);
            
            u.Id = id;

            try
            {
                await genericBusiness.Update(u);
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };

                return BadRequest(new BadRequestModel { Errors = errors });
            }

            return Ok();
        }

        //DELETE BY ID
        /// <summary>
        /// Delete a specific entity by id.
        /// </summary>
        /// <response code="201">Entity deleted successfully.</response>
        /// <response code="400">Unable to delete the entity due to validation error.</response>
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> DeleteById(Guid id)
        {
            try
            {
                await genericBusiness.DeleteById(id);
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