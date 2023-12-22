using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GrocifyApp.DAL.Models;

namespace GrocifyApp.DAL
{
    public class GrocifyAppContext : DbContext
    {
        public GrocifyAppContext(DbContextOptions<GrocifyAppContext> options) : base(options) { }

        public DbSet<ProductSection> ProductSections { get; set; }
        public DbSet<ProductMeasure> ProductMeasures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ShoppingListProduct> ShoppingListProducts { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
