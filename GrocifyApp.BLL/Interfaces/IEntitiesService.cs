using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null);
        Task<T?> Get(Guid id);
        Task Insert(T entity, CancellationTokenSource? token = null);
        Task Update(T entity, CancellationTokenSource? token = null);
        Task Delete(T entity, CancellationTokenSource? token = null);
        public Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel;
    }
}
