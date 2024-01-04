namespace GrocifyApp.DAL.Models
{
    public class Inventory : BaseEntity
    {
        public required string Name { get; set; }
        public required bool DefaultInventory { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
        public ICollection<InventoryProduct>? InventoryProducts { get; set; }
    }
}
