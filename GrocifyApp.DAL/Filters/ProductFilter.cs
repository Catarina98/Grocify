using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Filters
{
    public class ProductFilter : BaseSearchModelWithHouse<Product>
    {
        public Guid ProductSectionId { get; set; }
    }
}
