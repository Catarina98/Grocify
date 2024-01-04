namespace GrocifyApp.DAL.Models
{
    public class Recipe : BaseEntity
    {
        public required string Name { get; set; }
        public required int NumberOfPeople { get; set; }
        public required TimeSpan Time { get; set; }
        public required DifficultEnum Difficult { get; set; }
        public Guid? HouseId { get; set; }
        public House? House { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<RecipeProduct>? RecipeProducts { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }
        public required ICollection<Direction> Directions { get; set; }
    }

    public enum DifficultEnum
    {
        Easy,
        Medium,
        Hard
    }
}
