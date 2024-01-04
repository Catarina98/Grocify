namespace GrocifyApp.DAL.Models
{
    public class InventoryProduct : BaseEntity
    {
        public required int Quantity { get; set; }
        public required Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public required Guid InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
