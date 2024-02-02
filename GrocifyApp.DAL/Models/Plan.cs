namespace GrocifyApp.DAL.Models
{
    public class Plan : BaseEntityWithHouse
    {
        public required List<DaysOfWeek>? ChoosenDays { get; set; }
        public bool MonthlyView { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }
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
