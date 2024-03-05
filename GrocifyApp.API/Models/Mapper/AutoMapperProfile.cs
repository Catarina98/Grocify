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
            CreateMap<ProductSectionRequestModel, ProductSection>().ReverseMap();
            CreateMap<ProductSection, ProductSectionResponseModel>().ReverseMap();
            CreateMap<UserResponseModel, User>().ReverseMap();
            CreateMap<UserRequestModel, User>().ReverseMap();
            CreateMap<HouseResponseModel, House>().ReverseMap();
            CreateMap<HouseRequestModel, House>().ReverseMap();
            CreateMap<ProductResponseModel, Product>().ReverseMap();
            CreateMap<ProductRequestModel, Product>().ReverseMap();
            CreateMap<ProductMeasureResponseModel, ProductMeasure>().ReverseMap();
            CreateMap<ProductMeasureRequestModel, ProductMeasure>().ReverseMap();
            CreateMap<ShoppingListResponseModel, ShoppingList>().ReverseMap();
            CreateMap<ShoppingListRequestModel, ShoppingList>().ReverseMap();
            CreateMap<ShoppingListProductResponseModel, ShoppingListProduct>().ReverseMap();
            CreateMap<ShoppingListProductRequestModel, ShoppingListProduct>().ReverseMap();
            CreateMap<InventoryRequestModel, Inventory>().ReverseMap();
            CreateMap<InventoryResponseModel, Inventory>().ReverseMap();
            CreateMap<InventoryProductRequestModel, InventoryProduct>().ReverseMap();
            CreateMap<InventoryProductResponseModel, InventoryProduct>().ReverseMap();
        }
    }
}
