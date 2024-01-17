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
    public class ShoppingListController : GenericController<ShoppingList, ShoppingListRequestModel, ShoppingListResponseModel, BaseSearchModel>
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
    }
}
