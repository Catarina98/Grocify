using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null);
        Task<T?> Get(Guid id);
        Task Insert(T entity, CancellationTokenSource? token = null);
        Task Update(T entity, CancellationTokenSource? token = null);
        Task Delete(T entity, CancellationTokenSource? token = null);
        public Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel;
        Task<int> UpdateMultipleLeafType(Expression<Func<T, bool>> expression,
            Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyExpression,
            CancellationTokenSource? token = null);
        Task<int> DeleteMultipleLeafType(Expression<Func<T, bool>> expression,
            CancellationTokenSource? token = null);
    }
}
