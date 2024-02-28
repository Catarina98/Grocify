using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class MealController : GenericControllerWithHouse<Meal, MealRequestModel, MealResponseModel, BaseSearchModelWithHouse<Meal>>
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService, IMapper mapper, ICurrentUserService currentUserService)
            : base(mealService, mapper, currentUserService)
        {
            _mealService = mealService;
        }
    }
}
