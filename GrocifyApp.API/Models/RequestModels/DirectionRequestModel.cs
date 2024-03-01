namespace GrocifyApp.API.Models.RequestModels
{
    public class DirectionRequestModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid RecipeId { get; set; }

        /// <example>Boil 500mL of water</example>
        public required string Steps { get; set; }

        /// <example>Filling</example>
        public required string Name { get; set; }
    }
}
