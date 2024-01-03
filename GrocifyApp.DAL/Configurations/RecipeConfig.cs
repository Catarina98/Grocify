using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.Property(b => b.Difficult).HasMaxLength(8);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.Recipes)
                .HasForeignKey(x => x.HouseId);
        }
    }
}
