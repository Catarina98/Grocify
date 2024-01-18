using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Helpers;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductSectionService : EntitiesService<ProductSection>, IProductSectionService
    {
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ProductSection;

        public ProductSectionService(IRepository<ProductSection> repository) : base(repository)
        {
        }

        public async Task<List<ProductSection>> GetProductSectionsFromHouse(Guid houseId)
        {
            var productSections = await repository.GetWhere(GetFilterCondition(houseId));

            if (productSections == null || productSections.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoSectionsFoundInHouse);
            }

            return productSections;
        }

        protected override async Task<bool> Validate(ProductSection productSection)
        {
            if (productSection.HouseId != null)
            {
                if (await repository.AnyWhere(GetFilterCondition(productSection.HouseId.Value, productSection.Name)))
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.ProductSection));
                }
            }
            else
            {
                throw new CustomException(GenericConsts.Exceptions.HouseCannotBeNull);
            }

            return true;
        }

        private Expression<Func<ProductSection, bool>> GetFilterCondition(Guid houseId, string? name = null)
        {
            Expression<Func<ProductSection, bool>> filter = productMeasure => productMeasure.HouseId == houseId || productMeasure.HouseId == null;

            if (!string.IsNullOrEmpty(name))
            {
                filter = ExpressionsExtension<ProductSection>
                 .AndExpression(filter, productMeasure => productMeasure.Name == name);
            }

            return filter;
        }
    }
}
