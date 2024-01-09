namespace GrocifyApp.API.Models.ResponseModels
{
    public class RegisterResponseModel
    {
        public required byte[] PasswordHash { get; set; }

        public required byte[] PasswordSalt { get; set; }

        public required string Token { get; set; }
    }
}
