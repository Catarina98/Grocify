﻿using GrocifyApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace GrocifyApp.API.Models.RequestModels
{
    public class LoginRequestModel : BaseEntity
    {
        /// <example>joesmith@gmail.com</example>
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid email address.")]
        public required string Email { get; set; }

        public required string Password { get; set; } = String.Empty; //string.Empty needed?
    }
}