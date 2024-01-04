namespace GrocifyApp.DAL.Models
{
    public class Plan : BaseEntity
    {
        public required List<DaysOfWeek>? ChoosenDays { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
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
