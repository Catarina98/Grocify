using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesServiceWithHouse<T, TFilter> : IEntitiesService<T, TFilter> where T : BaseEntityWithHouse where TFilter : BaseSearchModelWithHouse<T>
    {
        public Guid? HouseId { get; set; }
    }
}
