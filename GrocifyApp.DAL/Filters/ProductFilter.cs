using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Filters
{
    public class ProductFilter : BaseSearchModelWithHouse<Product>
    {
        [ContainsSearch]
        public string? Name { get; set; }
        public Guid? ProductSectionId { get; set; }
    }
}
