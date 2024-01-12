using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductSectionService : EntitiesService<ProductSection>, IProductSectionService
    {
        public ProductSectionService(IRepository<ProductSection> repository) : base(repository)
        {
        }

        public override async Task Insert(ProductSection entity, CancellationTokenSource? token = null)
        {
            try
            {
                await base.Insert(entity, token);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new CustomException(string.Format(GenericConsts.Exceptions.EntityExistsFormat, GenericConsts.Entities.ProductSection));
            }
        }
    }
}
