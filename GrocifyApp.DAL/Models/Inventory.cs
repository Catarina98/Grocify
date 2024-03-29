﻿namespace GrocifyApp.DAL.Models
{
    public class Inventory : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public required bool DefaultInventory { get; set; }
        public ICollection<InventoryProduct>? InventoryProducts { get; set; }
    }
}
