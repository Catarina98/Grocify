using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Filters
{
    public class ProductFilter : BaseSearchModelWithHouse<Product>
    {
        [ContainsSearch] // Mark property with custom attribute
        public string? Name { get; set; }
        public Guid? ProductSectionId { get; set; }
    }
}
