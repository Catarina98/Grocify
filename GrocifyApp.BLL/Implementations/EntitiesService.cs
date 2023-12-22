using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrocifyApp.BLL.Implementations
{
    public class EntitiesService<T> : IEntitiesService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repository;

        public EntitiesService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> Get(Guid id)
        {
            return await repository.Get(id);
        }

        public async Task<W> GetById<W>(Guid id, Expression<Func<T, W>> selector)
        {
            return await repository.GetById(id, selector);
        }

        public async Task<List<T>> GetItems(Expression<Func<T, bool>>? expression = null, int skip = 0, int take = 20)
        {
            return await repository.GetWhere(expression, skip, take);
        }

        public async Task<List<W>> GetItems<W>(Expression<Func<T, W>> selector, Expression<Func<T, bool>>? expression = null, int skip = 0, int take = 20)
        {
            return await repository.GetNItemsWhere(selector, expression, skip, take);
        }

        public async Task<List<T>> GetItemsOrdered<Z>(Expression<Func<T, Z>> orderedBy, bool descending, Expression<Func<T, bool>>? expression = null, int skip = 0, int take = 20)
        {
            return await repository.GetNItemsWhereOrdered(orderedBy, descending, expression, skip, take);
        }

        public async Task<List<W>> GetItemsOrdered<W, Z>(Expression<Func<T, W>> selector, Expression<Func<T, Z>> orderedBy, bool descending = true, Expression<Func<T, bool>>? expression = null, int skip = 0, int take = 20)
        {
            return await repository.GetNItemsWhereOrdered(selector, orderedBy, descending, expression, skip, take);
        }

        public async Task<T> Insert(T entity, CancellationTokenSource? token = null)
        {
            return await repository.Insert(entity, token);
        }
    }
}
