using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductSectionService : EntitiesService<ProductSection>, IProductSectionService
    {
        private readonly IProductSectionRepository _productSectionRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ProductSection;

        public ProductSectionService(IProductSectionRepository repository) : base(repository)
        {
            _productSectionRepository = repository;
        }

        public async Task<List<ProductSection>> GetProductSectionsFromHouse(Guid houseId)
        {
            var productSections = await _productSectionRepository.GetProductSectionsFromHouse(houseId);

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
                if (await _productSectionRepository.CheckSectionExistsInHouse(productSection.HouseId.Value, productSection.Name))
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
    }
}
