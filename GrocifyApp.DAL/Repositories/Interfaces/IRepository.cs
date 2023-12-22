using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GrocifyApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll(CancellationTokenSource? token = null);
        Task<List<T>> GetWhere(Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10, CancellationTokenSource? token = null);
        Task<List<W>> GetNItemsWhere<W>(Expression<Func<T, W>> selector,
            Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10,
            string[]? includes = null, CancellationTokenSource? token = null);
        Task<List<T>> GetNItemsWhereOrdered<Z>(Expression<Func<T, Z>> orderedBy,
            bool descending, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10, string[]? includes = null,
            CancellationTokenSource? token = null);
        Task<List<W>> GetNItemsWhereOrdered<W, Z>(Expression<Func<T, W>> selector,
            Expression<Func<T, Z>> orderedBy, bool descending = true, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10, string[]? includes = null,
            CancellationTokenSource? token = null);
        Task<List<T>> GetNItemsWhere(Expression<Func<T, T>>? selector = null,
            Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10,
            string[]? includes = null, CancellationTokenSource? token = null);
        Task<T> Get(Guid id);
        Task<W> Get<W>(Guid id, Expression<Func<T, W>> selector) where W : BaseEntity;
        Task<W> GetById<W>(Guid id, Expression<Func<T, W>> selector);
        Task<T> Insert(T entity, CancellationTokenSource? token = null);
        Task Update(T entity, CancellationTokenSource? token = null);
        Task<int> UpdateMultipleLeafType(Expression<Func<T, bool>> expression,
            Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyExpression,
            CancellationTokenSource? token = null);
        Task Delete(T entity, CancellationTokenSource? token = null);
        Task DeleteById(Guid id, CancellationTokenSource? token = null);
        Task<T> DeleteByIdWithReturn(Guid id, CancellationTokenSource? token = null);
        Task DeleteMultiple(IEnumerable<T> list, CancellationTokenSource? token = null);
        Task<int> DeleteMultipleLeafType(Expression<Func<T, bool>> expression,
            CancellationTokenSource? token = null);
    }
}
