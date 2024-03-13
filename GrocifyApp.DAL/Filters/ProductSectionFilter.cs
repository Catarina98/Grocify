using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Filters
{
    public class ProductSectionFilter : BaseSearchModelWithHouse<ProductSection>
    {
        [ContainsSearch]
        public string? Name { get; set; }
    }
}
