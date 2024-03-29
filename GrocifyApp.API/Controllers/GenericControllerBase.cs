﻿using AutoMapper;
using GrocifyApp.API.Data.Consts.ENConsts;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DALConsts = GrocifyApp.DAL.Data.Consts.ENConsts;

namespace GrocifyApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GenericControllerBase<TEntity, TRequestModel, TResponseModel, TFilter, TService>(TService genericBusiness, IMapper mapper, ICurrentUserService currentUserService) : ControllerBase
        where TEntity : BaseEntity
        where TRequestModel : class
        where TResponseModel : class
        where TFilter : BaseSearchModel<TEntity>
        where TService : IEntitiesService<TEntity, TFilter>
    {
        public IEntitiesService<TEntity, TFilter> _genericBusiness { get; set; } = genericBusiness;
        public IMapper _mapper { get; set; } = mapper;
        public ICurrentUserService CurrentUserService { get; } = currentUserService;

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
                return NotFound(new { error = DALConsts.GenericConsts.Exceptions.EntityDoesNotExist });
            }
            
            var response = _mapper.Map<TResponseModel>(getEntity);

            return Ok(response);
        }

        //GET ALL ENTITIES
        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">No results found.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _genericBusiness.GetAll();
            
            return Ok(entities);
        }

        //GET ALL ENTITIES
        /// <summary>
        /// Gets entities filtered.
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">No results found.</response>
        [HttpGet("filtered")]
        public async Task<IActionResult> GetAllFiltered([FromQuery] TFilter filter)
        {
            var entities = await _genericBusiness.GetBySearchModel(filter);
            
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
                return BadRequest(new BadResponseModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            var u = _mapper.Map<TEntity>(entity);

            await InsertAction(u);

            var response = _mapper.Map<TResponseModel>(u);

            return Created(GenericConsts.APIResponses.EntityCreated, response);
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
                return BadRequest(new BadResponseModel
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                });
            }

            var u = _mapper.Map<TEntity>(entity);
            
            u.Id = id;

            await _genericBusiness.Update(u);

            return NoContent();
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
            await _genericBusiness.DeleteById(id);

            return NoContent();
        }

        protected virtual async Task InsertAction(TEntity entity)
        {
            await _genericBusiness.Insert(entity);
        }
    }
}