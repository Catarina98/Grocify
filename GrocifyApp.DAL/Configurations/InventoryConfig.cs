using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.Inventories)
                .HasForeignKey(x => x.HouseId);

            builder.HasIndex(u => new { u.DefaultInventory, u.HouseId }).IsUnique().HasFilter(nameof(Inventory.DefaultInventory) + " = 1");

            builder.HasIndex(u => new { u.Name, u.HouseId }).IsUnique();
        }
    }
}
