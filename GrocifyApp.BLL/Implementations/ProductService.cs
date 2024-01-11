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
                throw new NotFoundException(GenericConsts.Exceptions.NoUsersFoundInHouse);
            }

            return products;
        }
    }
}
