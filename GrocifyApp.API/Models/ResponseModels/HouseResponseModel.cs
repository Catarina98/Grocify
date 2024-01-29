namespace GrocifyApp.API.Models.ResponseModels
{
    public class HouseResponseModel
    {
        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>House Name</example>
        public required string Name { get; set; }
    }
}
