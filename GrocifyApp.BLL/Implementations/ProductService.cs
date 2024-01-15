using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductService : EntitiesService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }

        public async Task<List<Product>> GetProductsFromHouse(Guid houseId)
        {
            var products = await _productRepository.GetProductsFromHouse(houseId);

            if (products == null || products.Count == 0)
            {
                throw new NotFoundException(GenericConsts.Exceptions.NoPrdocutsFoundInHouse);
            }

            return products;
        }

        public override async Task Insert(Product product, CancellationTokenSource? token = null)
        {
            try
            {
                await InsertProduct(product);

                await base.Insert(product, token);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
            {
                throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.Product));
            }
        }

        public async Task InsertProduct(Product product, CancellationTokenSource? token = null)
        {

            if (product.HouseId != null)
            {
                var productsHouse = await GetProductsFromHouse(product.HouseId ?? Guid.Empty);

                if(!productsHouse.Any(x => x.Name == product.Name))
                {
                    await base.Insert(product, token);
                }
                else
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.Product));
                }
            }
        }
    }
}
