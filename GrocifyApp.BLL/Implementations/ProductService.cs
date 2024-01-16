using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Implementations;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductService : EntitiesService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.Product;

        public ProductService(IProductRepository repository) : base(repository)
        {
            _productRepository = repository;
        }

        public async Task<List<Product>> GetProductsFromHouse(Guid houseId)
        {
            var products = await _productRepository.GetProductsFromHouse(houseId);

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
                if (await _productRepository.CheckProductExistsInHouse(product.HouseId.Value, product.Name))
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
    }
}
