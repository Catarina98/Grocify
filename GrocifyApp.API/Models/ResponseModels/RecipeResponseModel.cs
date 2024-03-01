using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Models.ResponseModels
{
    public class RecipeResponseModel
    {
        ///<example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid Id { get; set; }

        /// <example>Recipe Name</example>
        public required string Name { get; set; }

        /// <example>6</example>
        public required int NumberOfPeople { get; set; }

        /// <example>55</example>
        public required TimeSpan Time { get; set; }

        /// <example>Difficult</example>
        public required DifficultEnum Difficult { get; set; }

        /// <example>image.jpg</example>
        public byte[]? Image { get; set; }
    }
}
