namespace GrocifyApp.DAL.Models
{
    public class UserHouse : BaseEntityWithHouse
    {
        public required Guid UserId { get; set; }
        public User? User { get; set; }
        public bool DefaultHouse { get; set; }
    }
}
