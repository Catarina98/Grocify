using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Implementations;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{
    public class ShoppingListController : GenericControllerWithHouse<ShoppingList, ShoppingListRequestModel, ShoppingListResponseModel, BaseSearchModelWithHouse<ShoppingList>>
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService, IMapper mapper, ICurrentUserService currentUserService)
            : base(shoppingListService, mapper, currentUserService)
        {
            _shoppingListService = shoppingListService;
        }

        /// <summary>
        /// Get products from shoppingList
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">ShoppingLits or products not found!</response>
        /// <response code="400">Unable to get products due to validation error.</response>
        [HttpGet("{id}/products")]
        public async Task<ActionResult<List<Product>>> GetProductsFromShoppingList(Guid id)
        {
            var products = await _shoppingListService.GetProductsFromShoppingList(id);

            return Ok(products);
        }

        /// <summary>
        /// Add products to shoppingList
        /// </summary>
        /// <response code="201">Products added successfully.</response>
        /// <response code="400">Unable to add products due to validation error.</response>
        [HttpPut("{id}/products")]
        public async Task<ActionResult> AddProductsToShoppingList(Guid id, [FromBody] IEnumerable<ShoppingListProductRequestModel> shoppingListProductRequest)
        {
            var shoppingListProducts = new Dictionary<Guid, ShoppingListProduct>();

            foreach (var sLProduct in shoppingListProductRequest)
            {
                var e = _mapper.Map<ShoppingListProduct>(sLProduct);

                e.ShoppingListId = id;

                shoppingListProducts.Add(e.ProductId, e);
            }

            await _shoppingListService.AddProductsToShoppingList(id, shoppingListProducts);

            return Ok();
        }

        /// <summary>
        /// Change default shoppingList
        /// </summary>
        /// <response code="201">Default shoppingList changed successfully.</response>
        /// <response code="400">Unable to changed default shoppingList due to validation error.</response>
        [HttpPut("{id}/setdefault")]
        public async Task<ActionResult> ChangeDefaultShoppingList(Guid id)
        {
            await _shoppingListService.ChangeDefaultShoppingList(id);

            return Ok();
        }
    }
}
