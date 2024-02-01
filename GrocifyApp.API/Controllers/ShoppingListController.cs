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
    public class ShoppingListController : GenericControllerWithHouse<ShoppingList, ShoppingListRequestModel, ShoppingListResponseModel, BaseSearchModel>
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService, IMapper mapper) : base(shoppingListService, mapper)
        {
            _shoppingListService = shoppingListService;
        }

        /// <summary>
        /// Get shoppingLists from house
        /// </summary>
        /// <response code="200">Success.</response>
        /// <response code="404">House or shoppingLists not found!</response>
        /// <response code="400">Unable to get shoppingLists due to validation error.</response>
        [HttpGet("{houseId}/shoppingLists")]
        public async Task<ActionResult<List<ShoppingList>>> GetShoppingListsFromHouse(Guid houseId)
        {
            try
            {
                var shoppingLists = await _shoppingListService.GetShoppingListsFromHouse(houseId);

                return Ok(shoppingLists);
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

            try
            {
                await _shoppingListService.AddProductsToShoppingList(id, shoppingListProducts);
            }
            catch (CustomException exception)
            {
                var errors = new List<string> { exception.Message };

                return BadRequest(new BadResponseModel { Errors = errors });
            }
            catch (Exception)
            {
                var errors = new List<string> { GenericConsts.Exceptions.Generic };

                return BadRequest(new BadResponseModel { Errors = errors });
            }

            return Ok();
        } //when i insert a product that already exists in list, the product quantity increment
    }
}
