namespace GrocifyApp.DAL.Models
{
    public class ProductSection : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
