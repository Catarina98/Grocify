using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class EntitiesService<T> : IEntitiesService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repository;

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

        public async Task<T?> Get(Guid id)
        {
            return await repository.Get(id);
        }

        public async Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null)
        {
            return await repository.GetAll(token);
        }

        public async Task<IEnumerable<T>> GetBySearchModel<TFilter>(TFilter filter, CancellationTokenSource? token = null) where TFilter : BaseSearchModel
        {
            return await repository.GetBySearchModel(filter, token);
        }

        public async Task Insert(T entity, CancellationTokenSource? token = null)
        {
            if (await Validate(entity))
            {
                await repository.Insert(entity, token);
            }
        }

        public async Task Update(T entity, CancellationTokenSource? token = null)
        {
            if (await Validate(entity))
            {
                await repository.Update(entity, token);
            }
        }

        protected virtual async Task<bool> Validate(T entity)
        {
            return true;
        }
    }
}
