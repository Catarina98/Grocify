namespace GrocifyApp.API.Models.ResponseModels
{
    public class LoginResponseModel
    {
        /// <example>5bj7UOXx02dsLKMqc77JCRwlXfF6T0QPA2RbKqUX3wOxE1lVEvTYZ5dhj2x3BTHJ</example>
        public required string Token { get; set; }

        /// <example>c7872109-cfd1-4332-b7f2-76c189987ae2</example>
        public required Guid UserId { get; set; }

        /// <example>false</example>
        public bool IsDarkMode { get; set; }
    }
}
