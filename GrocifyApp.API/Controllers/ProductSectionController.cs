using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController(IEntitiesService<ProductSection> service, IMapper mapper)
        : GenericController<ProductSection, ProductSectionRequestRequestModel, ProductSectionResponseModel,
            BaseSearchModel>(service, mapper);
}
