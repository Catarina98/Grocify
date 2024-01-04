using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class ShoppingListProductConfig : IEntityTypeConfiguration<ShoppingListProduct>
    {
        public void Configure(EntityTypeBuilder<ShoppingListProduct> builder)
        {
            builder.HasOne<ShoppingList>(x => x.ShoppingList)
                .WithMany(y => y.ShoppingListProducts)
                .HasForeignKey(x => x.ShoppingListId);

            builder.HasOne<Product>(x => x.Product)
                .WithMany(y => y.ShoppingListProducts)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
