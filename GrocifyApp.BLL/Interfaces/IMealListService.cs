using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IMealService : IEntitiesServiceWithHouse<Meal, BaseSearchModelWithHouse<Meal>>
    {
    }
}
