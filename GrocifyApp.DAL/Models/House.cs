namespace GrocifyApp.DAL.Models
{
    public class House : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<UserHouse>? UserHouses { get; set; }
    }
}
