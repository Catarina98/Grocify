using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductMeasureController : GenericControllerWithHouse<ProductMeasure, ProductMeasureRequestModel, ProductMeasureResponseModel, BaseSearchModel>
    {
        public ProductMeasureController(IEntitiesServiceWithHouse<ProductMeasure> productMeasureService, IMapper mapper) : base(productMeasureService, mapper)
        {
        }
    }
}
