using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Implementations;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ShoppingListService : EntitiesService<ShoppingList>, IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        //private readonly IRepository<ShoppingListProduct> _shoppingListProductRepository;
        private readonly IShoppingListProductRepository _shoppingListProductRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IShoppingListRepository repository, IShoppingListProductRepository shoppingListProductRepository) : base(repository)
        {
            _shoppingListRepository = repository;

            _shoppingListProductRepository = shoppingListProductRepository;
        }

        public async Task<List<ShoppingList>> GetShoppingListsFromHouse(Guid houseId)
        {
            var shoppingLists = await _shoppingListRepository.GetShoppingListsFromHouse(houseId);

            if (shoppingLists == null || shoppingLists.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoListsFoundInHouse);
            }

            return shoppingLists;
        }

        protected override async Task<bool> Validate(ShoppingList shoppingList)
        {
            if (!await _shoppingListRepository.AnyShoppingListInHouse(shoppingList.HouseId))
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
            var updatedEntitiesCount = await _shoppingListProductRepository.UpdateMultipleLeafType(
                x => x.ShoppingListId == id && shoppingListProducts.ContainsKey(x.ProductId),
                y => y.SetProperty(z => z.Quantity,
                    z => z.Quantity + shoppingListProducts[z.ProductId].Quantity));

            if (updatedEntitiesCount < shoppingListProducts.Count)
            {
                var entitiesToInsert = await _shoppingListProductRepository.GetWhere(
                    x => x.ShoppingListId == id && !shoppingListProducts.ContainsKey(x.ProductId), x => shoppingListProducts[x.ProductId]);

                await _shoppingListProductRepository.InsertMultiple(entitiesToInsert, token);
            }
        }
    }
}
