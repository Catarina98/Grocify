using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class EntitiesService<T, TFilter> : IEntitiesService<T, TFilter> where T : BaseEntity where TFilter : BaseSearchModel<T>
    {
        protected readonly IRepository<T> repository;

        protected virtual string entityName
        {
            get
            {
                string typeName = typeof(T).Name;

                var fieldInfo = typeof(GenericConsts.Entities).GetField(typeName);

                if (fieldInfo != null)
                {
                    return (string)fieldInfo.GetValue(null)!;
                }
                else
                {
                    return GenericConsts.Entities.Entity;
                }
            }

            set
            {
                entityName = value;
            }
        }

        public EntitiesService(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task Delete(T entity, CancellationTokenSource? token = null)
        {
            await repository.Delete(entity, token);
        }

        public async Task DeleteById(Guid id, CancellationTokenSource? token = null)
        {
            await repository.DeleteById(id, token);
        }

        public virtual async Task<T?> Get(Guid id)
        {
            return await repository.Get(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null)
        {
            return await repository.GetAll(token);
        }

        public virtual async Task<IEnumerable<T>> GetBySearchModel(TFilter filter, CancellationTokenSource? token = null)
        {
            return await repository.GetBySearchModel(filter, token);
        }

        public virtual async Task Insert(T entity, CancellationTokenSource? token = null)
        {
            if (await Validate(entity))
            {                
                try
                {
                    await repository.Insert(entity, token);

                    await FinishInsert(entity);
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
                    throw new SQLException(ex, entityName);
                }
            }
        }

        public async Task Update(T entity, bool saveChanges = true, CancellationTokenSource? token = null)
        {
            if (await Validate(entity))
            {
                await repository.Update(entity, saveChanges, token);
            }
        }

        protected virtual async Task<bool> Validate(T entity)
        {
            return true;
        }

        protected virtual async Task FinishInsert(T entity)
        {
        }
    }
}
