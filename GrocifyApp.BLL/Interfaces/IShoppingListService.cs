﻿using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IShoppingListService : IEntitiesService<ShoppingList>
    {
        Task<List<ShoppingList>> GetShoppingListsFromHouse(Guid houseId);
    }
}