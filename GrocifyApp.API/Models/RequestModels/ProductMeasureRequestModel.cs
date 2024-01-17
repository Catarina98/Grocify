using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductMeasureRequestModel
    {
        /// <example>g</example>
        [Required] //can i delete this?
        public required string Name { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public Guid? HouseId { get; set; }
    }
}
