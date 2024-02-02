namespace GrocifyApp.DAL.Models
{
    public abstract class BaseEntityWithHouse : BaseEntity
    {
        public virtual Guid? HouseId { get; set; }
        public House? House { get; set; }
    }
}
