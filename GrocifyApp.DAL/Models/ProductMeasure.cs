namespace GrocifyApp.DAL.Models
{
    public class ProductMeasure : BaseEntity
    {
        public required string Name { get; set; }
        public Guid? HouseId { get; set; }
        public House? House { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
