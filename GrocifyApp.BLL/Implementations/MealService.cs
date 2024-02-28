using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using GrocifyApp.DAL.Filters;

namespace GrocifyApp.BLL.Implementations
{
    public class MealService : EntitiesServiceWithHouse<Meal, BaseSearchModelWithHouse<Meal>>, IMealService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Meal;

        public MealService(IRepository<Meal> repository) : base(repository)
        {
        }

        public override async Task Insert(Meal entity, CancellationTokenSource? token = null)
        {
            var meals = await repository.GetAll();

            if(meals != null && meals.Any())
            {
                entity.OrderIndex = meals.Count() + 1;
            }
            
            await base.Insert(entity, token);
        }
    }
}
