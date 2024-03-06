using GrocifyApp.BLL.Data.Consts.ENConsts;
using DALConsts = GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using GrocifyApp.DAL.Filters;

namespace GrocifyApp.BLL.Implementations
{
    public class InventoryService : EntitiesServiceWithHouse<Inventory, BaseSearchModelWithHouse<Inventory>>, IInventoryService
    {
        private readonly IRepository<InventoryProduct> _inventoryProductRepository;
        protected override string entityName { get; set; } = GenericConsts.Entities.Inventory;

        public InventoryService(IRepository<Inventory> repository, IRepository<InventoryProduct> inventoryProductRepository) : base(repository)
        {
            _inventoryProductRepository = inventoryProductRepository;
        }

        /// <summary>
        /// If a house doesn't have any inventories yet, when you add a new one, it will automatically become the default inventory
        /// </summary>
        protected override async Task<bool> Validate(Inventory inventory)
        {
            await base.Validate(inventory);

            if (!await repository.AnyWhere(x => x.HouseId == inventory.HouseId))
            {
                inventory.DefaultInventory = true;
            }

            return true;
        }

        /// <summary>
        /// Update the quantity of the products in the inventory.
        /// Update the quantity of the products that already exist in the inventory.
        /// Insert the products that don't exist in the inventory.
        /// </summary>
        /// <param name="id">Inventory Id</param>
        /// <param name="inventoryProducts">Products to insert or update in the inventory</param>
        public async Task AddProductsToInventory(Guid id, Dictionary<Guid, InventoryProduct> inventoryProducts, CancellationTokenSource? token = null)
        {
            var entitiesToUpdate = await _inventoryProductRepository.GetWhere(
                x => x.InventoryId == id && inventoryProducts.Keys.Contains(x.ProductId));

            foreach (var entity in entitiesToUpdate)
            {
                entity.Quantity += inventoryProducts[entity.ProductId].Quantity;

                await _inventoryProductRepository.Update(entity, false, token);
            }

            if (entitiesToUpdate.ToList().Count < inventoryProducts.Count)
            {
                var entitiesToInsert = inventoryProducts
                    .Where(pair => !entitiesToUpdate.Any(entity => entity.ProductId == pair.Key))
                    .Select(pair => pair.Value);

                await _inventoryProductRepository.InsertMultiple(entitiesToInsert, false, token);
            }

            await _inventoryProductRepository.SaveChangesAsync(token);
        }

        public async Task ChangeDefaultInventory(Guid newDefaultId)
        {
            var getInventory = await repository.Get(newDefaultId);

            if (getInventory == null)
            {
                throw new NotFoundException(DALConsts.GenericConsts.Exceptions.NotFoundException);
            }

            getInventory.DefaultInventory = true;

            await repository.UpdateMultipleLeafType(x => x.HouseId == HouseId && x.DefaultInventory == true, x => x.SetProperty(y => y.DefaultInventory, false));

            await repository.Update(getInventory);
        }
    }
}
