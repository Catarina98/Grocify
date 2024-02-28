namespace GrocifyApp.API.Models.RequestModels
{
    public class MealRequestModel
    {
        /// <example>Breakfast</example>
        public required string Name { get; set; }

        /// <example>Blue</example>
        public required string Color { get; set; }

        /// <example>1</example>
        public required int OrderIndex { get; set; }
    }
}
