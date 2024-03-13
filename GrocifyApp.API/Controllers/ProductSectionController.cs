using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController : GenericControllerWithHouse<ProductSection, ProductSectionRequestModel, ProductSectionResponseModel, ProductSectionFilter>
    {
        public ProductSectionController(IEntitiesServiceWithHouse<ProductSection, ProductSectionFilter> productSectionService, IMapper mapper, ICurrentUserService currentUserService)
            : base(productSectionService, mapper, currentUserService)
        {
        }
    }
}
