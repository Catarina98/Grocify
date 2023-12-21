namespace GrocifyApp.DAL.Models
{
    public class ProductSection : BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        //Todo: Add FK HouseId

        public ProductSection(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
