using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL.Configurations
{
    public class ShoppingListConfig : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.ShoppingLists)
                .HasForeignKey(x => x.HouseId);
        }
    }
}
