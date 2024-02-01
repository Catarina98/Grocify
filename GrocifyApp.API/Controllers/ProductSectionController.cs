using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController : GenericControllerWithHouse<ProductSection, ProductSectionRequestModel, ProductSectionResponseModel, BaseSearchModel>
    {
        private readonly IProductSectionService _productSectionService;

        public ProductSectionController(IProductSectionService productSectionService, IMapper mapper) : base(productSectionService, mapper)
        {
            _productSectionService = productSectionService;
        }

        /// <summary>
        /// Get product sections from house
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">House or product sections not found!</response>
        /// <response code="400">Unable to get product sections due to validation error.</response>
        [HttpGet("{houseId}/products")]
        public async Task<ActionResult<List<ProductSection>>> GetProductSectionsFromHouse(Guid houseId)
        {
            try
            {
                var productSections = await _productSectionService.GetProductSectionsFromHouse(houseId);

                return Ok(productSections);
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
    }
}
