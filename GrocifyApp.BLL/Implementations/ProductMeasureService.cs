using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductMeasureService : EntitiesService<ProductMeasure>, IProductMeasureService
    {
        public ProductMeasureService(IRepository<ProductMeasure> repository) : base(repository)
        {
        }

        public override async Task Insert(ProductMeasure entity, CancellationTokenSource? token = null)
        {
            try
            {
                await base.Insert(entity, token);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new CustomException(string.Format(GenericConsts.Exceptions.EntityExistsFormat, GenericConsts.Entities.ProductMeasure));
            }
        }
    }
}
