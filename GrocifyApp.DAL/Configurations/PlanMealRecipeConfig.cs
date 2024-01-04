using GrocifyApp.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GrocifyApp.DAL.Configurations
{
    public class PlanMealRecipeConfig : IEntityTypeConfiguration<PlanMealRecipe>
    {
        public void Configure(EntityTypeBuilder<PlanMealRecipe> builder)
        {
            builder.HasOne<Plan>(x => x.Plan)
                .WithMany(y => y.PlanMealRecipes)
                .HasForeignKey(x => x.PlanId);

            builder.HasOne<Meal>(x => x.Meal)
                .WithMany(y => y.PlanMealRecipes)
                .HasForeignKey(x => x.MealId);

            builder.HasOne<Recipe>(x => x.Recipe)
                .WithMany(y => y.PlanMealRecipes)
                .HasForeignKey(x => x.RecipeId);
        }
    }
}
