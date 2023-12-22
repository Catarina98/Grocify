namespace GrocifyApp.DAL.Models
{
    public class Plan : BaseEntity
    {
        public required string Name { get; set; }
        public required string ChoosenDays { get; set; }
        public bool MonthlyView { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }

        //Todo: Add FK HouseId
    }
}
