﻿namespace GrocifyApp.API.Models.ResponseModels
{
    public class ShoppingListResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Shopping List Name</example>
        public required string Name { get; set; }

        /// <example>DefaultList</example>
        public required bool DefaultList { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid HouseId { get; set; }
    }
}
