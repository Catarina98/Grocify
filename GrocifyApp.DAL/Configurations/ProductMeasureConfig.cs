using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Configurations
{
    public class ProductMeasureConfig : IEntityTypeConfiguration<ProductMeasure>
    {
        public void Configure(EntityTypeBuilder<ProductMeasure> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.ProductMeasures)
                .HasForeignKey(x => x.HouseId);

            builder.HasIndex(u => u.Name).IsUnique();
            //builder.HasIndex(u => new { u.Name, u.HouseId }).IsUnique();
        }
    }
}
