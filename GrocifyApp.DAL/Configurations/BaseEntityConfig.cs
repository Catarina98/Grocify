using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class BaseEntityConfig : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.UseTpcMappingStrategy();

            builder.Property(b => b.CreatedAt).HasDefaultValueSql("getutcdate()");
            builder.Property(b => b.ModifiedAt).HasDefaultValueSql("getutcdate()");
        }
    }
}
