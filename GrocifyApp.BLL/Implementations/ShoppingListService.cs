using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Implementations
{
    public class ShoppingListService : EntitiesService<ShoppingList>, IShoppingListService
    {
        private readonly IRepository<ShoppingListProduct> _shoppingListProductRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IRepository<ShoppingList> repository, IRepository<ShoppingListProduct> shoppingListProductRepository) : base(repository)
        {
            _shoppingListProductRepository = shoppingListProductRepository;
        }

        public async Task<List<ShoppingList>> GetShoppingListsFromHouse(Guid houseId)
        {
            var shoppingLists = await repository.GetWhere(GetFilterCondition(houseId));

            if (shoppingLists == null || shoppingLists.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoListsFoundInHouse);
            }

            return shoppingLists;
        }

        /// <summary>
        /// If a house doesn't have any shopping lists yet, when you add a new one, it will automatically become the default list
        /// </summary>
        protected override async Task<bool> Validate(ShoppingList shoppingList)
        {
            if (!await repository.AnyWhere(GetFilterCondition(shoppingList.HouseId)))
            {
                shoppingList.DefaultList = true;
            }

            return true;
        }

        /// <summary>
        /// Update the quantity of the products in the shopping list.
        /// Update the quantity of the products that already exist in the shopping list.
        /// Insert the products that don't exist in the shopping list.
        /// </summary>
        /// <param name="id">Shopping list Id</param>
        /// <param name="shoppingListProducts">Products to insert or update in the shopping list</param>
        public async Task AddProductsToShoppingList(Guid id, Dictionary<Guid, ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null)
        {
            var entitiesToUpdate = await _shoppingListProductRepository.GetWhere(
                x => x.ShoppingListId == id && shoppingListProducts.Keys.Contains(x.ProductId));

            foreach (var entity in entitiesToUpdate)
            {
                entity.Quantity += shoppingListProducts[entity.ProductId].Quantity;

                await _shoppingListProductRepository.Update(entity, false, token);
            }

            if (entitiesToUpdate.ToList().Count < shoppingListProducts.Count)
            {
                var entitiesToInsert = shoppingListProducts
                    .Where(pair => !entitiesToUpdate.Any(entity => entity.ProductId == pair.Key))
                    .Select(pair => pair.Value);

                await _shoppingListProductRepository.InsertMultiple(entitiesToInsert, false, token);
            }

            await _shoppingListProductRepository.SaveChangesAsync(token);
        }

        private Expression<Func<ShoppingList, bool>> GetFilterCondition(Guid houseId)
        {
            return x => x.HouseId == houseId;
        }
    }
}
