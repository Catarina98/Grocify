using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Helpers;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using System.Linq.Expressions;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductService : EntitiesServiceWithHouse<Product>, IProductService
    {
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.Product;

        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }

        public async Task<List<Product>> GetProductsFromHouse(Guid houseId)
        {
            var products = await repository.GetWhere(GetFilterCondition(houseId));

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInHouse);
            }

            return products;
        }

        protected override async Task<bool> Validate(Product product)
        {
            if (product.HouseId != null)
            {
                if (await repository.AnyWhere(GetFilterCondition(product.HouseId.Value, product.Name)))
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.Product));
                }
            }
            else
            {
                throw new CustomException(GenericConsts.Exceptions.HouseCannotBeNull);
            }

            return true;
        }

        private Expression<Func<Product, bool>> GetFilterCondition(Guid houseId, string? name = null)
        {
            Expression<Func<Product, bool>> filter = product => product.HouseId == houseId || product.HouseId == null;

            if (!string.IsNullOrEmpty(name))
            {
                filter = ExpressionsExtension<Product>
                 .AndExpression(filter, product => product.Name == name);
            }

            return filter;
        }
    }
}
