using GrocifyApp.DAL.Models;
using System.Text.Json.Serialization;

namespace GrocifyApp.API.Models.RequestModels
{
    public class HouseRequestModel
    {
        /// <example>House Name</example>
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<UserHouse>? UserHouses { get; set; }
    }
}
