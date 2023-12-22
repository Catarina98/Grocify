namespace GrocifyApp.DAL.Models
{
    public class Direction : BaseEntity
    {
        public string? Name { get; set; }
        public required Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
