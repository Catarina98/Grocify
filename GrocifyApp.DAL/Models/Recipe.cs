namespace GrocifyApp.DAL.Models
{
    public class Recipe : BaseEntity
    {
        public required string Name { get; set; }
        public required int NumberOfPeople { get; set; }
        public required DateTime Time { get; set; }
        public required string Difficult { get; set; }
        public string? Image { get; set; }
        public ICollection<RecipeProduct>? RecipeProducts { get; set; }

        //Todo: Add FK HouseId
    }
}
