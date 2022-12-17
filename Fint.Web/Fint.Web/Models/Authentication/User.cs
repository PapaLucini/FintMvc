using Fint.Web.Models.Authentication.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Fint.Web.Models.Authentication
{
    public class User : IUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        public string Password { get; set;}
        public string UserId { get; set; }
    }
}