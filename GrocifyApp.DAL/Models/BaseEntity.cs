namespace GrocifyApp.DAL.Models
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
