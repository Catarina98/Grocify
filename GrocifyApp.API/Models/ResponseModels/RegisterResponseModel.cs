namespace GrocifyApp.API.Models.ResponseModels
{
    public class RegisterResponseModel
    {
        public byte[] PasswordHash { get; set; } = default!;

        public byte[] PasswordSalt { get; set; } = default!;

        public string Token { get; set; } = default!;
    }
}
