namespace GrocifyApp.DAL.Models
{
    public class ProductSection : BaseEntity
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public Guid? HouseId { get; set; }
        public House? House { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
