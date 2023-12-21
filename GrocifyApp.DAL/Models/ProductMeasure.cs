namespace GrocifyApp.DAL.Models
{
    public class ProductMeasure : BaseEntity
    {
        public string Name { get; set; }

        //Todo: Add FK HouseId

        public ProductMeasure(string name)
        {
            Name = name;
        }
    }
}
