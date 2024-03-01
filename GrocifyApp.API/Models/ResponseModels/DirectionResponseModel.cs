namespace GrocifyApp.API.Models.ResponseModels
{
    public class DirectionResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid RecipeId { get; set; }

        /// <example>Steps of the recipe</example>
        public required string Steps { get; set; }

        /// <example>Name of the steps</example>
        public required string Name { get; set; }
    }
}