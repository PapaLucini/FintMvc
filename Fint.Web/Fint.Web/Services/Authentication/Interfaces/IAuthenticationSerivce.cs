using Fint.Web.Models.Authentication.Interfaces;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fint.Web.Services.Authentication.Interfaces
{
    public interface IAuthenticationSerivce 
    {
        Task<FirebaseAuthLink> CreateUser(IUser user);

        Task<FirebaseAuthLink> AuthenticateUser (IUser user);

        Task<IUser> CreateUserOnDatabase (string userId);
    }
}