namespace GrocifyApp.DAL.Models
{
    public class RecipeProduct : BaseEntity
    {
        public string? Name { get; set; }
        public required int Quantity { get; set; }
        public required Guid RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public string? Measure { get; set; }
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
