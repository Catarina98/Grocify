using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Implementations;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{
    public class ProductController : GenericControllerWithHouse<Product, ProductRequestModel, ProductResponseModel, ProductFilter>
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService, IMapper mapper, ICurrentUserService currentUserService)
            : base(productService, mapper, currentUserService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products with sections
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">Products not found!</response>
        /// <response code="400">Unable to get products due to validation error.</response>
        [HttpGet("productswsections")]
        public async Task<ActionResult<IEnumerable<ShoppingListProduct>>> GetProductsFromShoppingList()
        {
            var products = await _productService.GetProductsWithSections();

            return Ok(products);
        }
    }
}
