using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class ProductSectionConfig : IEntityTypeConfiguration<ProductSection>
    {
        public void Configure(EntityTypeBuilder<ProductSection> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.ProductSections)
                .HasForeignKey(x => x.HouseId);

            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}
