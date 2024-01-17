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
        private readonly IRepository<ShoppingListProduct> _shoppingListProductRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IShoppingListRepository repository, IRepository<ShoppingListProduct> shoppingListProductRepository) : base(repository)
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

        public async Task AddProductsToShoppingList(Guid id, IEnumerable<ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null)
        {            
            //get the products from list and check if already exist the products to add, if so increment the quantity
            //need to create on repo getproducts
            //on remove products do the same but instead of increment, decrement the quantity

            //var shoppingListProductsNew = new List<ShoppingListProduct>();

            //foreach (var sLProduct in shoppingListProducts)
            //{
            //    shoppingListProductsNew.Add(new ShoppingListProduct
            //    {
            //        Quantity = sLProduct.Quantity,
            //        ProductId = sLProduct.ProductId,
            //        ShoppingListId = id
            //    });
            //}

            try
            {
                await _shoppingListProductRepository.InsertMultiple(shoppingListProducts, token);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new CustomException(GenericConsts.Exceptions.InsertDuplicateUserInHouse);
            }
        }
    }
}
