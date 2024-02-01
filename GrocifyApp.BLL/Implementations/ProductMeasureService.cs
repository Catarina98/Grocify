using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Helpers;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductMeasureService : EntitiesServiceWithHouse<ProductMeasure>, IProductMeasureService
    {
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ProductMeasure;

        public ProductMeasureService(IRepository<ProductMeasure> repository) : base(repository)
        {
        }

        public async Task<List<ProductMeasure>> GetProductMeasuresFromHouse(Guid houseId)
        {
            var productMeasures = await repository.GetWhere(GetFilterCondition(houseId));

            if (productMeasures == null || productMeasures.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoMeasuresFoundInHouse);
            }

            return productMeasures;
        }


        protected override async Task<bool> Validate(ProductMeasure productMeasure)
        {
            if (productMeasure.HouseId != null)
            {
                if (await repository.AnyWhere(GetFilterCondition(productMeasure.HouseId.Value, productMeasure.Name)))
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.ProductMeasure));
                }
            }
            else
            {
                throw new CustomException(GenericConsts.Exceptions.HouseCannotBeNull);
            }

            return true;
        }

        private Expression<Func<ProductMeasure, bool>> GetFilterCondition(Guid houseId, string? name = null)
        {
            Expression<Func<ProductMeasure, bool>> filter = productMeasure => productMeasure.HouseId == houseId || productMeasure.HouseId == null;

            if (!string.IsNullOrEmpty(name))
            {
                filter = ExpressionsExtension<ProductMeasure>
                 .AndExpression(filter, productMeasure => productMeasure.Name == name);
            }

            return filter;
        }
    }
}
