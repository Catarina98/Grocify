﻿namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductMeasureResponseModel
    {
        ///<example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Product Measure Name</example>
        public required string Name { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public Guid? HouseId { get; set; }
    }
}
