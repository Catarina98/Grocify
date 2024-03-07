using GrocifyApp.BLL.Implementations;
using GrocifyApp.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GrocifyApp.BLL
{
    public static class DependencyInjectionRegistry
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IEntitiesService<,>), typeof(EntitiesService<,>));
            services.AddScoped(typeof(IEntitiesServiceWithHouse<,>), typeof(EntitiesServiceWithHouse<,>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IMealService, MealService>();
        }
    }
}
