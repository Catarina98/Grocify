namespace GrocifyApp.DAL.Models
{
    public class ProductMeasure : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Product>? Products { get; set; }

        //Todo: Add FK HouseId
    }
}
