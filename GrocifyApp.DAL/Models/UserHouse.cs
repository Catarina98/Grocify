namespace GrocifyApp.DAL.Models
{
    public class UserHouse : BaseEntity
    {
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public required Guid HouseId { get; set; }
        public House? House { get; set; }
        public bool DefaultHouse { get; set; }
    }
}
