namespace GrocifyApp.API.Models.ResponseModels
{
    public class BadRequestModel
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
