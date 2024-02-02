namespace GrocifyApp.DAL.Models
{
    public class ProductMeasure : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
