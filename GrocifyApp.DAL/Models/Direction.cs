namespace GrocifyApp.DAL.Models
{
    public class Direction : BaseEntity
    {
        public required Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public required string Steps { get; set; }
        public string? Name { get; set; }
    }
}
