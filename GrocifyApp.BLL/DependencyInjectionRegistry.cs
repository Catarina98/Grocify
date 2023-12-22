using GrocifyApp.BLL.Implementations;
using GrocifyApp.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GrocifyApp.BLL
{
    public static class DependencyInjectionRegistry
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IEntitiesService<>), typeof(EntitiesService<>));
        }
    }
}
