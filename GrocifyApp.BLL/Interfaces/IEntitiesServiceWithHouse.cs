using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesServiceWithHouse<T> : IEntitiesService<T> where T : BaseEntityWithHouse
    {
        public Guid? HouseId { get; set; }
    }
}
