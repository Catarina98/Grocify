using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController : GenericControllerWithHouse<ProductSection, ProductSectionRequestModel, ProductSectionResponseModel, BaseSearchModel>
    {
        public ProductSectionController(IEntitiesServiceWithHouse<ProductSection> productSectionService, IMapper mapper) : base(productSectionService, mapper)
        {
        }
    }
}
