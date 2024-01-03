using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductSectionRequestModel, ProductSection>().ReverseMap();
        }
    }
}
