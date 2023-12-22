using GrocifyApp.BLL.Interfaces;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Controllers
{
    public class ProductSectionController : GenericRestController<ProductSection>
    {
        public ProductSectionController(IEntitiesService<ProductSection> _repository) : base(_repository)
        {
        }
    }
}
