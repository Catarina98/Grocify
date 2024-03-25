using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;
using GrocifyApp.DAL.Filters;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductService : EntitiesServiceWithHouse<Product, ProductFilter>, IProductService
    {
        protected override string entityName { get; set; } = GenericConsts.Entities.Product;

        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }
        
        public async Task<List<Product>> GetProductsWithSections()
        {
            var products = await repository.GetWhereInclude<ProductSection>(x => x.HouseId == HouseId || x.HouseId == null, 
                product => product.ProductSection!);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoProductsFoundInHouse);
            }

            return products;
        }
    }
}
