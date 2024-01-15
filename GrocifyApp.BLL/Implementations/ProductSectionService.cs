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

        public override async Task Insert(ProductSection productSection, CancellationTokenSource? token = null)
        {
            await InsertProductSection(productSection);

            await base.Insert(productSection, token);
        }

        public async Task InsertProductSection(ProductSection productSection, CancellationTokenSource? token = null)
        {
            if (productSection.HouseId != null)
            {
                var productSectionsHouse = await GetProductSectionsFromHouse(productSection.HouseId ?? Guid.Empty);

                if (!productSectionsHouse.Any(x => x.Name == productSection.Name))
                {
                    await base.Insert(productSection, token);
                }
                else
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.ProductSection));
                }
            }
        }
    }
}
