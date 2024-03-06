using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrocifyApp.API.Controllers
{
    public class InventoryController : GenericControllerWithHouse<Inventory, InventoryRequestModel, InventoryResponseModel, BaseSearchModelWithHouse<Inventory>>
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService, IMapper mapper, ICurrentUserService currentUserService)
            : base(inventoryService, mapper, currentUserService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Add products to inventory
        /// </summary>
        /// <response code="201">Products added successfully.</response>
        /// <response code="400">Unable to add products due to validation error.</response>
        [HttpPut("{id}/products")]
        public async Task<ActionResult> AddProductsToInventory(Guid id, [FromBody] IEnumerable<InventoryProductRequestModel> inventoryProductRequest)
        {
            var inventoryProducts = new Dictionary<Guid, InventoryProduct>();

            foreach (var iProduct in inventoryProductRequest)
            {
                var e = _mapper.Map<InventoryProduct>(iProduct);

                e.InventoryId = id;

                inventoryProducts.Add(e.ProductId, e);
            }

            await _inventoryService.AddProductsToInventory(id, inventoryProducts);

            return Ok();
        }

        /// <summary>
        /// Change default inventory
        /// </summary>
        /// <response code="201">Default inventory changed successfully.</response>
        /// <response code="400">Unable to changed default inventory due to validation error.</response>
        [HttpPut("{id}/setdefault")]
        public async Task<ActionResult> ChangeDefaultInventory(Guid id)
        {
            await _inventoryService.ChangeDefaultInventory(id);

            return Ok();
        }
    }
}
