using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using GrocifyApp.DAL.Exceptions;

namespace GrocifyApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly IDbContextFactory<GrocifyAppContext> _dbContextFact;
        protected readonly ILogger<Repository<T>> _logger;

        public Repository(IDbContextFactory<GrocifyAppContext> dbContextFact,
            ILogger<Repository<T>> logger)
        {
            _dbContextFact = dbContextFact;
            _logger = logger;
        }

        public async Task<List<T>> GetAll(CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>().Where(x => x.IsDeleted != true);

            return await ToListAsync(entities, token);
        }

        public async Task<List<T>> GetWhere(Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10, CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            var query = filter == null ? entities : entities.Where(filter);

            query = query.Skip(skip).Take(take);

            return await ToListAsync(query, token);
        }

        public async Task<List<W>> GetNItemsWhere<W>(Expression<Func<T, W>> selector,
            Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10,
            string[]? includes = null, CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            var query = filter == null ? entities : entities.Where(filter);

            return await GetItemsList(query, selector, skip, take, token);
        }

        public async Task<List<T>> GetNItemsWhereOrdered<Z>(Expression<Func<T, Z>> orderedBy,
            bool descending, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10, string[]? includes = null,
            CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            var query = filter == null ? entities : entities.Where(filter);

            return await GetItemsListOrdered(query, orderedBy, descending, null, skip, take, token);
        }

        public async Task<List<W>> GetNItemsWhereOrdered<W, Z>(Expression<Func<T, W>> selector,
            Expression<Func<T, Z>> orderedBy, bool descending = true, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10,
            string[]? includes = null, CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            var query = filter == null ? entities : entities.Where(filter);

            return await GetItemsListOrdered(query, selector, orderedBy, descending, skip, take, token);
        }

        public async Task<List<T>> GetNItemsWhere(Expression<Func<T, T>>? selector = null,
            Expression<Func<T, bool>>? filter = null, int skip = 0, int take = 10,
            string[]? includes = null, CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            var query = filter == null ? entities : entities.Where(filter);

            return await GetItemsList(query, selector, skip, take, token);
        }
        public async Task<T> Get(Guid id)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            var entity = await entities.FindAsync(id);

            if (entity != null && !entity.IsDeleted)
            {
                return entity;
            }
            else
            {
                throw new EntityDoesNotExistException();
            }
        }

        public async Task<W> Get<W>(Guid id, Expression<Func<T, W>> selector) where W : BaseEntity
        {
            return await GetById(id, selector);
        }

        public async Task<W> GetById<W>(Guid id, Expression<Func<T, W>> selector)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            var entity = await entities.Where(x => x.Id == id && x.IsDeleted != true)
                .Select(selector)
                .FirstOrDefaultAsync();

            if (entity != null)
            {
                return entity;
            }
            else
            {
                throw new EntityDoesNotExistException();
            }
        }

        public async Task<T> Insert(T entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            entities.Add(entity);

            await SaveChangesAsync(context, token);

            return entity;
        }

        public async Task Update(T entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            entity.ModifiedAt = DateTime.UtcNow;

            var entry = entities.Update(entity);

            entry.Property(x => x.Id).IsModified = false;
            entry.Property(x => x.CreatedAt).IsModified = false;
            entry.Property(x => x.IsDeleted).IsModified = false;

            await SaveChangesAsync(context, token);
        }

        public async Task<int> UpdateMultipleLeafType(Expression<Func<T, bool>> expression,
            Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyExpression,
            CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            return await entities.Where(expression).ExecuteUpdateAsync(setPropertyExpression);
        }

        public async Task Delete(T? entity, CancellationTokenSource? token = null)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            entities.Remove(entity);

            await SaveChangesAsync(context, token);
        }

        public async Task DeleteById(Guid id, CancellationTokenSource? token = null)
        {
            await DeleteMultipleLeafType(x => x.Id == id, token);
        }

        public async Task<T> DeleteByIdWithReturn(Guid id, CancellationTokenSource? token = null)
        {
            var entity = await Get(id);

            await Delete(entity, token);

            return entity!;
        }

        public async Task DeleteMultiple(IEnumerable<T> list,
            CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            entities.RemoveRange(list);

            await SaveChangesAsync(context, token);
        }

        public async Task<int> DeleteMultipleLeafType(Expression<Func<T, bool>> expression,
            CancellationTokenSource? token = null)
        {
            using var context = await _dbContextFact.CreateDbContextAsync();

            var entities = context.Set<T>();

            return await entities.Where(expression).ExecuteDeleteAsync();
        }

        protected async Task<List<T>> GetNItemsWhere(IIncludableQueryable<T, object> include,
            Expression<Func<T, T>>? selector = null, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10, CancellationTokenSource? token = null)
        {
            var query = filter == null ? include : include.Where(filter);

            return await GetItemsList(query, selector, skip, take, token);
        }

        protected async Task<List<W>> GetNItemsWhere<W>(IIncludableQueryable<T, object> include,
            Expression<Func<T, W>> selector, Expression<Func<T, bool>>? filter = null,
            int skip = 0, int take = 10, CancellationTokenSource? token = null)
        {
            var query = filter == null ? include : include.Where(filter);

            return await GetItemsList(query, selector, skip, take, token);
        }

        protected async Task<List<W>> GetItemsList<W>(IQueryable<T> query,
            Expression<Func<T, W>> selector, int skip = 0, int take = 10,
            CancellationTokenSource? token = null)
        {
            var itemsQuery = query.OrderByDescending(x => x.ModifiedAt)
                .Skip(skip);

            if (take > 0)
            {
                itemsQuery = itemsQuery.Take(take);
            }

            return await ToListAsync(itemsQuery.Select(selector), token);
        }

        protected async Task<List<T>> GetItemsListOrdered<Z>(IQueryable<T> query,
            Expression<Func<T, Z>> orderedBy, bool descending,
            Expression<Func<T, T>>? selector = null,
            int skip = 0, int take = 10, CancellationTokenSource? token = null)
        {
            var itemsQuery = descending ? query.OrderByDescending(orderedBy).Skip(skip) :
                query.OrderBy(orderedBy).Skip(skip);

            if (take > 0)
            {
                itemsQuery = itemsQuery.Take(take);
            }

            if (selector != null)
            {
                itemsQuery = itemsQuery.Select(selector);
            }

            return await ToListAsync(itemsQuery, token);
        }

        protected async Task<List<W>> GetItemsListOrdered<W, Z>(IQueryable<T> query,
            Expression<Func<T, W>> selector, Expression<Func<T, Z>> orderedBy, bool descending = true,
            int skip = 0, int take = 10, CancellationTokenSource? token = null)
        {
            var itemsQuery = descending ? query.OrderByDescending(orderedBy)
                .Skip(skip).Take(take).Select(selector)
                : query.OrderBy(orderedBy).Skip(skip).Take(take).Select(selector);

            return await ToListAsync(itemsQuery, token);
        }

        protected async Task<List<T>> GetItemsList(IQueryable<T> query,
            Expression<Func<T, T>>? selector = null, int skip = 0, int take = 10,
            CancellationTokenSource? token = null)
        {
            var itemsQuery = query.OrderByDescending(x => x.CreatedAt)
                .Skip(skip);

            if (take > 0)
            {
                itemsQuery = itemsQuery.Take(take);
            }

            itemsQuery = selector == null ? itemsQuery :
                itemsQuery.Select(selector);

            return await ToListAsync(itemsQuery, token);
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

        private async Task SaveChangesAsync(GrocifyAppContext context,
            CancellationTokenSource? token = null)
        {
            if (token != null)
            {
                try
                {
                    await context.SaveChangesAsync(token.Token);
                }
                catch (SqlException e) when (token.IsCancellationRequested)
                {
                    _logger.LogInformation(e.Message);

                    throw;
                }
            }
            else
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
