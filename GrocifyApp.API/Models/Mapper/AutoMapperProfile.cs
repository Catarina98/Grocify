using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductSectionRequestRequestModel, ProductSection>().ReverseMap();
            CreateMap<ProductSectionResponseModel, ProductSection>().ReverseMap();
        }
    }
}
