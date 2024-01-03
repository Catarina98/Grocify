namespace GrocifyApp.DAL.Models
{
    public class House : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<UserHouse>? UserHouses { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Meal>? Meals { get; set; }
        public ICollection<Plan>? Plans { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }
        public ICollection<ShoppingList>? ShoppingLists { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ProductSection>? ProductSections { get; set; }
        public ICollection<ProductMeasure>? ProductMeasures { get; set; }
    }
}
