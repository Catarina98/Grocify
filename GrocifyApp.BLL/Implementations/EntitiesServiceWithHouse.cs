using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class EntitiesServiceWithHouse<T, TFilter> : EntitiesService<T, TFilter>, IEntitiesServiceWithHouse<T, TFilter>
        where T : BaseEntityWithHouse where TFilter : BaseSearchModelWithHouse<T>
    {
        public EntitiesServiceWithHouse(IRepository<T> repository) : base(repository)
        {
        }

        public Guid? HouseId { get; set; }

        public override async Task<T?> Get(Guid id)
        {
            return await repository.GetSingleWhere(x => x.Id == id && x.HouseId == HouseId || x.HouseId == null);
        }

        public override async Task<IEnumerable<T>> GetAll(CancellationTokenSource? token = null)
        {
            var list = await repository.GetWhere(x =>  x.HouseId == HouseId || x.HouseId == null);

            if (list == null || list.Count == 0)
            {
                throw new NotFoundException(string.Format(GenericConsts.Exceptions.NoListsFoundInHouse, entityName));
            }

            return list;
        }

        public override Task<IEnumerable<T>> GetBySearchModel(TFilter filter, CancellationTokenSource? token = null)
        {
            filter.HouseIdFilter = HouseId;

            return base.GetBySearchModel(filter, token);
        }

        protected override Task<bool> Validate(T entity)
        {
            entity.HouseId = HouseId;

            return base.Validate(entity);
        }
    }
}
