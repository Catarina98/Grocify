namespace GrocifyApp.DAL.Models
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public bool IsDarkMode { get; set; }
        public required string Password { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public ICollection<UserHouse>? UserHouses { get; set; }
    }
}
