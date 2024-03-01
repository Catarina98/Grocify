using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class RecipeController : GenericControllerWithHouse<Recipe, RecipeRequestModel, RecipeResponseModel, BaseSearchModelWithHouse<Recipe>>
    {
        public RecipeController(IEntitiesServiceWithHouse<Recipe, BaseSearchModelWithHouse<Recipe>> recipeService, IMapper mapper, ICurrentUserService currentUserService)
            : base(recipeService, mapper, currentUserService)
        {
        }

        //todo: Remember on UI
        // - first: we insert the details of the recipe (recipe controller)
        // - second: we insert the ingredients of the recipe (recipeProduct)
        // - third: we insert the directions of the recipe (direction controller) we need the RecipeId, so after everything filled, we need to insert
        // the recipe, and after that, insert the direction the the recipeId returned from the insert method.
    }
}
