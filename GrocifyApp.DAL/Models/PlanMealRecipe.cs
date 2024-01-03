namespace GrocifyApp.DAL.Models
{
    public class PlanMealRecipe : BaseEntity
    {
        public required DateTime Date { get; set; }
        public required Guid MealId { get; set; }
        public Meal? Meal { get; set; }
        public required Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public Guid? PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
