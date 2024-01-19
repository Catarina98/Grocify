using GrocifyApp.BLL.Data.Consts.ENConsts;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Exceptions;
using GrocifyApp.DAL.Models;
using GrocifyApp.DAL.Repositories.Interfaces;

namespace GrocifyApp.BLL.Implementations
{
    public class ProductMeasureService : EntitiesService<ProductMeasure>, IProductMeasureService
    {
        private readonly IProductMeasureRepository _productMeasureRepository;
        protected override string duplicateEntityException { get; set; } = GenericConsts.Entities.ProductMeasure;

        public ProductMeasureService(IProductMeasureRepository repository) : base(repository)
        {
            _productMeasureRepository = repository;
        }

        public async Task<List<ProductMeasure>> GetProductMeasuresFromHouse(Guid houseId)
        {
            var productMeasures = await _productMeasureRepository.GetProductMeasuresFromHouse(houseId);

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
                if (await _productMeasureRepository.CheckMeasureExistsInHouse(productMeasure.HouseId.Value, productMeasure.Name))
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
    }
}
