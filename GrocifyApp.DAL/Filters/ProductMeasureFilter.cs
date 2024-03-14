using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Filters
{
    public class ProductMeasureFilter : BaseSearchModelWithHouse<ProductMeasure>
    {
        [ContainsSearch]
        public string? Name { get; set; }
    }
}
