﻿using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class UserHouseConfig : IEntityTypeConfiguration<UserHouse>
    {
        public void Configure(EntityTypeBuilder<UserHouse> builder)
        {
            builder.HasOne<User>(x => x.User)
                .WithMany(y => y.UserHouses)
                .HasForeignKey(x => x.UserId);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.UserHouses)
                .HasForeignKey(x => x.HouseId);

            builder
              .HasIndex(nameof(UserHouse.UserId), nameof(UserHouse.HouseId))
              .IsUnique();

            builder.HasIndex(u => new { u.DefaultHouse, u.UserId }).IsUnique().HasFilter(nameof(UserHouse.DefaultHouse) + " = 1");
        }
    }
}
