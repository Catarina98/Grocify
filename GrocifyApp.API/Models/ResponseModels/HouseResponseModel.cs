namespace GrocifyApp.API.Models.ResponseModels
{
    public class HouseResponseModel
    {
        /// <example>Id</example>
        public required Guid Id { get; set; }

        /// <example>House Name</example>
        public required string Name { get; set; }
    }
}
