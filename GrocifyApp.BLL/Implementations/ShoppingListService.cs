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

        public async Task AddProductsToShoppingList(Guid id, IEnumerable<ShoppingListProduct> shoppingListProducts, CancellationTokenSource? token = null)
        {
            //get the products from list and check if already exist the products to add, if so increment the quantity
            //need to create on repo getproducts
            //on remove products do the same but instead of increment, decrement the quantity

            //OPTION 1
            var sLProductsToInsert = new List<ShoppingListProduct>();

            var sLProductsToUpdate = new List<ShoppingListProduct>();

            //get all products in list with shoppingListProducts as argument

            foreach (var sLProduct in shoppingListProducts)
            {
                var getSLProduct = await _shoppingListProductRepository.CheckProductExistInList(id, sLProduct.ProductId);

                if (getSLProduct != null)
                {
                    getSLProduct.Quantity += sLProduct.Quantity;

                    await _shoppingListProductRepository.Update(getSLProduct);
                }
                else
                {
                    sLProductsToInsert.Add(sLProduct);
                }
            }

            await _shoppingListProductRepository.InsertMultiple(sLProductsToInsert, token);


            //OPTION 2
            //foreach (var sLProduct in shoppingListProducts)
            //{
            //    try
            //    {
            //        await _shoppingListProductRepository.Insert(sLProduct, token);
            //    }
            //    catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            //    {
            //        var getSLProduct = await _shoppingListProductRepository.CheckProductExistInList(id, sLProduct.ProductId);

            //        if (getSLProduct != null)
            //        {
            //            getSLProduct.Quantity += sLProduct.Quantity;

            //            await _shoppingListProductRepository.Update(getSLProduct);
            //        }
            //        else
            //        {
            //            throw new CustomException(GenericConsts.Exceptions.InsertDuplicateProductInList);
            //        }
            //    }
            //}
        }
    }
}
