namespace GrocifyApp.DAL.Models
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<UserHouse>? UserHouses { get; set; }
    }
}
