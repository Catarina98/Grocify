namespace GrocifyApp.DAL.Models
{
    public class Plan : BaseEntity
    {
        public required string Name { get; set; }
        public required List<DaysOfWeek>? ChoosenDays { get; set; }
        public bool MonthlyView { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }

        //Todo: Add FK HouseId
    }

    public enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
