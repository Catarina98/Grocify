﻿using AutoMapper;
using GrocifyApp.API.Models.RequestModels;
using GrocifyApp.API.Models.ResponseModels;
using GrocifyApp.API.Services;
using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Filters;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductController : GenericControllerWithHouse<Product, ProductRequestModel, ProductResponseModel, BaseSearchModel>
    {
        public ProductController(IEntitiesServiceWithHouse<Product> productService, IMapper mapper, ICurrentUserService currentUserService)
            : base(productService, mapper, currentUserService)
        {
        }
    }
}
