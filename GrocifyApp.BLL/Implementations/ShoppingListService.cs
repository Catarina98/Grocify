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
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IShoppingListRepository repository) : base(repository)
        {
            _shoppingListRepository = repository;
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
    }
}
