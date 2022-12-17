using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fint.Web.Models.Authentication.Interfaces
{
    public interface IUser
    {
        string UserId { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}