using GrocifyApp.DAL.Models;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Interfaces
{
    public interface IEntitiesService<T> where T : BaseEntity
    {
        Task<T> Get(Guid id);
        Task<W> GetById<W>(Guid id, Expression<Func<T, W>> selector);
        public Task<List<T>> GetItems(Expression<Func<T, bool>>? expression = null,
            int skip = 0, int take = 20);
        public Task<List<W>> GetItems<W>(Expression<Func<T, W>> selector,
            Expression<Func<T, bool>>? expression = null, int skip = 0, int take = 20);
        public Task<List<T>> GetItemsOrdered<Z>(Expression<Func<T, Z>> orderedBy,
            bool descending, Expression<Func<T, bool>>? expression = null,
            int skip = 0, int take = 20);
        public Task<List<W>> GetItemsOrdered<W, Z>(Expression<Func<T, W>> selector,
            Expression<Func<T, Z>> orderedBy, bool descending = true, Expression<Func<T, bool>>? expression = null,
            int skip = 0, int take = 20);
        Task<T> Insert(T entity, CancellationTokenSource? token = null);
    }
}
