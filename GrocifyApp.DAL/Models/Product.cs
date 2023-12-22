namespace GrocifyApp.DAL.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required Guid ProductMeasureId { get; set; }
        public ProductMeasure? ProductMeasure { get; set; }
        public required Guid ProductSectionId { get; set; }
        public ProductSection? ProductSection { get; set; }
        public ICollection<ShoppingListProduct>? ShoppingListProducts { get; set; }
        public ICollection<InventoryProduct>? InventoryProducts { get; set; }

        //Todo: Add FK HouseId
    }
}
