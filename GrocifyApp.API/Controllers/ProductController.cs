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
    [Route("api/[controller]")]
    public class ProductController : GenericController<Product, ProductRequestModel, ProductResponseModel, BaseSearchModel>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper) : base(productService, mapper)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get products from house
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">House or products not found!</response>
        /// <response code="400">Unable to get products due to validation error.</response>
        [HttpGet("{houseId}/products")]
        public async Task<ActionResult<List<Product>>> GetProductsFromHouse(Guid houseId)
        {
            try
            {
                var products = await _productService.GetProductsFromHouse(houseId);

                return Ok(products);
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
