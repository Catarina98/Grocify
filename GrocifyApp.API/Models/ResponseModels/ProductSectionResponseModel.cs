﻿namespace GrocifyApp.API.Models.ResponseModels
{
    public class ProductSectionResponseModel
    {
        ///<example>Id</example>
        public Guid Id { get; set; }

        /// <example>Meat</example>
        public required string Name { get; set; }

        /// <example>Chicken Icon</example>
        public required string Icon { get; set; }
    }
}
