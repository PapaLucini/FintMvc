using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Authentication.Interfaces
{
    public interface ICustomAuthenticationProvider
    {
        FirebaseAuthProvider Provider { get; set; }
    }
}