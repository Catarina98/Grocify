﻿namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductRequestModel
    {
        /// <example>Milk</example>
        public required string Name { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductMeasureId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductSectionId { get; set; }
    }
}
