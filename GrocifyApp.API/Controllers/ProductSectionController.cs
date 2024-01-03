using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController : GenericController<ProductSection, ProductSectionRequestModel, ProductSectionResponseModel, BaseSearchModel>
    {
        public ProductSectionController(IEntitiesService<ProductSection> service, IMapper mapper, ILogger<GenericController<ProductSection, ProductSectionRequestModel, ProductSectionResponseModel, BaseSearchModel>> logger) : base(service, mapper, logger)
        {
        }
    }
}
