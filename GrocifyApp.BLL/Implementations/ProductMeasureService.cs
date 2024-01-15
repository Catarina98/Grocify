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

        public override async Task Insert(ProductMeasure productMeasure, CancellationTokenSource? token = null)
        {
            await InsertProductMeasure(productMeasure);

            await base.Insert(productMeasure, token);
        }

        public async Task InsertProductMeasure(ProductMeasure productMeasure, CancellationTokenSource? token = null)
        {
            if (productMeasure.HouseId != null)
            {
                var productMeasuresHouse = await GetProductMeasuresFromHouse(productMeasure.HouseId ?? Guid.Empty);

                if (!productMeasuresHouse.Any(x => x.Name == productMeasure.Name))
                {
                    await base.Insert(productMeasure, token);
                }
                else
                {
                    throw new CustomException(string.Format(GenericConsts.Exceptions.DuplicateEntityFormat, GenericConsts.Entities.ProductMeasure));
                }
            }
        }
    }
}
