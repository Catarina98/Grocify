namespace GrocifyApp.API.Models.ResponseModels
{
    public class BadRequestModel //this is request or response?
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
