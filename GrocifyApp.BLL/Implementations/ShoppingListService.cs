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
        private readonly IRepository<ShoppingList> _shoppingListRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ShoppingList;

        public ShoppingListService(IRepository<ShoppingList> repository) : base(repository)
        {
            _shoppingListRepository = repository;
        }

        public async Task<List<ShoppingList>> GetShoppingListsFromHouse(Guid houseId)
        {
            var shoppingLists = await _shoppingListRepository.GetWhere(GetFilterCondition(houseId));

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
            if (!await _shoppingListRepository.AnyWhere(GetFilterCondition(shoppingList.HouseId)))
            {
                shoppingList.DefaultList = true;
            }

            return true;
        }

        private Expression<Func<ShoppingList, bool>> GetFilterCondition(Guid houseId)
        {
            return x => x.HouseId == houseId;
        }
    }
}
