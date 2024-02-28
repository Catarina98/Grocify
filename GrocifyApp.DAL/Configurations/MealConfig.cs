using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class MealConfig : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.Meals)
                .HasForeignKey(x => x.HouseId);

            builder.HasIndex(u => new { u.Name, u.HouseId }).IsUnique();

            builder.HasIndex(u => new { u.Color, u.HouseId }).IsUnique();

            builder.HasIndex(u => new { u.OrderIndex, u.HouseId }).IsUnique();
        }
    }
}
