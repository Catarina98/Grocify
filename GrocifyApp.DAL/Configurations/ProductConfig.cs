using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<ProductMeasure>(x => x.ProductMeasure)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.ProductMeasureId);

            builder.HasOne<ProductSection>(x => x.ProductSection)
                .WithMany(y => y.Products)
                .HasForeignKey(x => x.ProductMeasureId);
        }
    }
}
