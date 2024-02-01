using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null);
        Task<T?> Get(Guid id);
        Task Insert(T entity, CancellationTokenSource? token = null);
        Task Update(T entity, bool saveChanges = true, CancellationTokenSource? token = null);
        Task Delete(T entity, CancellationTokenSource? token = null);
        Task DeleteById(Guid id, CancellationTokenSource? token = null);
        Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel;
    }
}
