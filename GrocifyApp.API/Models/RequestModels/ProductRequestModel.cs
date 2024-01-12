using GrocifyApp.DAL.Models;
using System.Text.Json.Serialization;

namespace GrocifyApp.API.Models.RequestModels
{
    public class ProductRequestModel
    {
        /// <example>Milk</example>
        public required string Name { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductMeasureId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid ProductSectionId { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public Guid? HouseId { get; set; }

        [JsonIgnore]
        public ICollection<UserHouse>? UserHouses { get; set; }
    }
}
