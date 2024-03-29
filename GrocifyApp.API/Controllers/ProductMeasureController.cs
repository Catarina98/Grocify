﻿using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductMeasureController : GenericControllerWithHouse<ProductMeasure, ProductMeasureRequestModel, ProductMeasureResponseModel, ProductMeasureFilter>
    {
        public ProductMeasureController(IEntitiesServiceWithHouse<ProductMeasure, ProductMeasureFilter> productMeasureService, IMapper mapper, ICurrentUserService currentUserService)
            : base(productMeasureService, mapper, currentUserService)
        {
        }
    }
}
