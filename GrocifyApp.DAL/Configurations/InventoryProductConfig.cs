using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class InventoryProductConfig : IEntityTypeConfiguration<InventoryProduct>
    {
        public void Configure(EntityTypeBuilder<InventoryProduct> builder)
        {
            builder.HasOne<Inventory>(x => x.Inventory)
                .WithMany(y => y.InventoryProducts)
                .HasForeignKey(x => x.InventoryId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.InventoryProducts)
                .HasForeignKey(x => x.ProductId);

            builder.HasIndex(u => new { u.InventoryId, u.ProductId }).IsUnique();
        }
    }
}
