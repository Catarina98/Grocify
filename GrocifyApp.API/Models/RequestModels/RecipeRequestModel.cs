using GrocifyApp.DAL.Models;

namespace GrocifyApp.API.Models.RequestModels
{
    public class RecipeRequestModel
    {
        /// <example>Lasagne</example>
        public required string Name { get; set; }

        /// <example>6</example>
        public required int NumberOfPeople { get; set; }

        /// <example>55</example>
        public required TimeSpan Time { get; set; }

        /// <example>Medium</example>
        public required DifficultEnum Difficult { get; set; }

        /// <example>lasagne.jpg</example>
        public byte[]? Image { get; set; }
    }
}
