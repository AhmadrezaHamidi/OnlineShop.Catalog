using System;
using Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Domain.Shop.Auth
{

    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }


}

