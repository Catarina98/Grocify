namespace GrocifyApp.API.Models.RequestModels
{
    public class MealRequestModel
    {
        /// <example>Breakfast</example>
        public required string Name { get; set; }

        /// <example>1</example>
        public required int OrderIndex { get; set; }
    }
}
