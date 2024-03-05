using GrocifyApp.BLL.Data.Consts.ENConsts;
using DALConsts = GrocifyApp.DAL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using GrocifyApp.DAL.Filters;

namespace GrocifyApp.BLL.Implementations
{
    public class ShoppingListService : EntitiesServiceWithHouse<ShoppingList, BaseSearchModelWithHouse<ShoppingList>>, IShoppingListService
    {
        private readonly IRepository<ShoppingListProduct> _shoppingListProductRepository;
        protected override string entityName { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IRepository<ShoppingList> repository, IRepository<ShoppingListProduct> shoppingListProductRepository) : base(repository)
        {
            _shoppingListProductRepository = shoppingListProductRepository;
        }

        /// <summary>
        /// If a house doesn't have any shopping lists yet, when you add a new one, it will automatically become the default list
        /// </summary>
        protected override async Task<bool> Validate(ShoppingList shoppingList)
        {
            await base.Validate(shoppingList);

            if (!await repository.AnyWhere(x => x.HouseId == shoppingList.HouseId))
            {
                shoppingList.DefaultList = true;
            }

            return true;
        }
        
        public async Task<Dictionary<Product, int>> GetProductsFromShoppingList(Guid shoppingListId)
        {
            var products = await _shoppingListProductRepository.GetWhere<Product>(productList => 
                productList.ShoppingListId == shoppingListId, productList => productList.Product!);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInList);
            }

            var productQuantities = new Dictionary<Product, int>();

            foreach (var product in products)
            {
                if (productQuantities.ContainsKey(product))
                {
                    productQuantities[product]++;
                }
                else
                {
                    productQuantities.Add(product, 1);
                }
            }

            return productQuantities;
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

        public async Task ChangeDefaultShoppingList(Guid newDefaultId)
        {
            var getShoppingList = await repository.Get(newDefaultId);

            if (getShoppingList == null)
            {
                throw new NotFoundException(DALConsts.GenericConsts.Exceptions.NotFoundException);
            }

            getShoppingList.DefaultList = true;

            await repository.UpdateMultipleLeafType(x => x.HouseId == HouseId && x.DefaultList == true, x => x.SetProperty(y => y.DefaultList, false));

            await repository.Update(getShoppingList);
        }
    }
}
