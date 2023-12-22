using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class RecipeProductConfig : IEntityTypeConfiguration<RecipeProduct>
    {
        public void Configure(EntityTypeBuilder<RecipeProduct> builder)
        {
            builder.HasOne<Recipe>(x => x.Recipe)
                .WithMany(y => y.RecipeProducts)
                .HasForeignKey(x => x.RecipeId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.RecipeProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
