namespace GrocifyApp.DAL.Models
{
    public class Plan : BaseEntity
    {
        public required string ChosenDays { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
        public bool MonthlyView { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }
    }
}
