namespace GrocifyApp.DAL.Models
{
    public class Meal : BaseEntity
    {
        public required string Name { get; set; }
        public required int OrderIndex { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }
    }
}
