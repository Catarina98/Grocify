namespace GrocifyApp.DAL.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string ProductMeasureId { get; set; }
        public ProductMeasure? ProductMeasure { get; set; }
        public required string ProductSectionId { get; set; }
        public ProductSection? ProductSection { get; set; }

        //Todo: Add FK HouseId
    }
}
