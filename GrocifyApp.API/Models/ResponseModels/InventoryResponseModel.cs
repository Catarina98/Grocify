namespace GrocifyApp.API.Models.ResponseModels
{
    public class InventoryResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Inventory Name</example>
        public required string Name { get; set; }

        /// <example>DefaultInventory</example>
        public required bool DefaultInventory { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid HouseId { get; set; }
    }
}
