﻿using System.Text.Json.Serialization;

namespace GrocifyApp.DAL.Models
{
    public class Product : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public required Guid ProductMeasureId { get; set; }
        public ProductMeasure? ProductMeasure { get; set; }
        public required Guid ProductSectionId { get; set; }
        public ProductSection? ProductSection { get; set; }

        [JsonIgnore]
        public ICollection<ShoppingListProduct>? ShoppingListProducts { get; set; }
        public ICollection<InventoryProduct>? InventoryProducts { get; set; }
        public ICollection<RecipeProduct>? RecipeProducts { get; set; }
    }
}
