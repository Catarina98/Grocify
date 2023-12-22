﻿namespace GrocifyApp.DAL.Models
{
    public class Meal : BaseEntity
    {
        public required string Name { get; set; }
        public required int OrderIndex { get; set; }
        public ICollection<PlanMealRecipe>? PlanMealRecipes { get; set; }

        //Todo: Add FK HouseId
    }
}
