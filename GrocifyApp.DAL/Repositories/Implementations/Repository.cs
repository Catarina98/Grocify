using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Helpers;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly GrocifyAppContext _dbContext;
        protected readonly ILogger<Repository<T>> _logger;
        private DbSet<T> entities;

        public Repository(GrocifyAppContext dbContext)
        {
            _dbContext = dbContext;

            entities = _dbContext.Set<T>();
        }

        public async Task Delete(T? entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);

            await SaveChangesAsync(token);
        }

        public async Task DeleteById(Guid id, CancellationTokenSource? token = null)
        {
            var entity = await Get(id);

            await Delete(entity, token);
        }

        public virtual async Task<T?> Get(Guid id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null)
        {
            return await entities.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task Insert(T entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);

            await SaveChangesAsync(token);
        }

        public async Task InsertMultiple(IEnumerable<T> entitiesToAdd, bool saveChanges = true, CancellationTokenSource? token = null)
        {
            if(entitiesToAdd == null)
            {
                throw new ArgumentNullException(nameof(entitiesToAdd));
            }

            entities.AddRange(entitiesToAdd);

            if (saveChanges)
            {
                await SaveChangesAsync(token);
            }
        }

        public async Task Update(T entity, bool saveChanges = true, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Update(entity);

            if(saveChanges)
            {
                await SaveChangesAsync(token);
            }
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> filter, CancellationTokenSource? token = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var s = entities.Where(filter);

            return await ToListAsync(s, token);
        }

        public async Task<IEnumerable<TSelector>> GetWhere<TSelector>(Expression<Func<T, bool>> filter,
            Expression<Func<T, TSelector>> selector, CancellationTokenSource? token = null)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var s = entities.Where(filter).Select(selector);

            return await ToListAsync(s, token);
        }

        public async Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            Expression<Func<T, bool>> expressions = ToExpression(filter);

            var s = entities.Where(expressions)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return await ToListAsync(s, token);
        }

        public virtual Expression<Func<T, bool>> ToExpression<TFilter>(TFilter filter, CancellationTokenSource? token = null)
        {
            var expressions = new List<Expression<Func<T, bool>>>();

            var result = ExpressionsExtension<T>
                .MergeAndExpressions(expressions);

            return result;
        }

        public async Task<int> UpdateMultipleLeafType(Expression<Func<T, bool>> expression,
            Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyExpression,
            CancellationTokenSource? token = null)
        {
            return await entities.Where(expression).ExecuteUpdateAsync(setPropertyExpression);
        }

        public async Task<int> DeleteMultipleLeafType(Expression<Func<T, bool>> expression,
            CancellationTokenSource? token = null)
        {
            return await entities.Where(expression).ExecuteDeleteAsync();
        }

        private async Task<List<W>> ToListAsync<W>(IQueryable<W> query,
            CancellationTokenSource? token = null)
        {
            if (token != null)
            {
                try
                {
                    return await query.ToListAsync(token.Token);
                }
                catch (SqlException e) when (token.IsCancellationRequested)
                {
                    _logger.LogInformation(e.Message);

                    throw;
                }
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task SaveChangesAsync(CancellationTokenSource? token = null)
        {
            if (token != null)
            {
                try
                {
                    await _dbContext.SaveChangesAsync(token.Token);
                }
                catch (SqlException e) when (token.IsCancellationRequested)
                {
                    _logger.LogInformation(e.Message);

                    throw;
                }
            }
            else
            {
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
