namespace GrocifyApp.DAL.Models
{
    public class Meal : BaseEntityWithHouse
    {
        public required string Name { get; set; }
        public required string Color { get; set; }
        public required int OrderIndex { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }
    }
}
