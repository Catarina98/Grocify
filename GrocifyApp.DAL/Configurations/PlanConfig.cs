using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrocifyApp.DAL.Configurations
{
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(60);

            builder.HasOne<House>(x => x.House)
                .WithMany(y => y.Plans)
                .HasForeignKey(x => x.HouseId);

            builder.Property(x => x.ChoosenDays)
             .HasColumnName(nameof(Plan.ChoosenDays))
             .HasConversion(x => ConvertToDb(x), x => ConvertFromDb(x));

        }

        private static string? ConvertToDb(List<DaysOfWeek>? choosenDays)
        {
            return choosenDays == null ? null : String.Join(";", choosenDays);
        }

        private static List<DaysOfWeek>? ConvertFromDb(string? choosenDays)
        {
            if (choosenDays == null)
            {
                return null;
            }

            var daysArray = choosenDays.Split(';');
            var result = new List<DaysOfWeek>();

            foreach (var dayString in daysArray)
            {
                if (Enum.TryParse(dayString, out DaysOfWeek day))
                {
                    result.Add(day);
                }
            }

            return result;
        }
    }
}
