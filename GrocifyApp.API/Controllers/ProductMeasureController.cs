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
    public class ProductMeasureController : GenericControllerWithHouse<ProductMeasure, ProductMeasureRequestModel, ProductMeasureResponseModel, BaseSearchModel>
    {
        private readonly IProductMeasureService _productMeasureService;

        public ProductMeasureController(IProductMeasureService productMeasureService, IMapper mapper) : base(productMeasureService, mapper)
        {
            _productMeasureService = productMeasureService;
        }

        /// <summary>
        /// Get product measures from house
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">House or product measures not found!</response>
        /// <response code="400">Unable to get product measures due to validation error.</response>
        [HttpGet("{houseId}/products")]
        public async Task<ActionResult<List<ProductMeasure>>> GetProductMeasuresFromHouse(Guid houseId)
        {
            try
            {
                var productMeasures = await _productMeasureService.GetProductMeasuresFromHouse(houseId);

                return Ok(productMeasures);
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
