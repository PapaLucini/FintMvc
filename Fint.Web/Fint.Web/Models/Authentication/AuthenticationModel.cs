using System.ComponentModel.DataAnnotations;

namespace Fint.Web.Models.Authentication
{
    public class AuthenticationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        public string Password { get; set;}
    }
}