using Fint.Web.Authentication;
using Fint.Web.Authentication.Interfaces;
using Fint.Web.Constants;
using Fint.Web.Models.Authentication;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fint.Web.Controllers
{
    public class AccountController : Controller
    {
        private ICustomAuthenticationProvider authProvider;
        public AccountController()
        {
            authProvider = CustomFirebaseAuthProvider.GetInstance();
        }

        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(authProvider.UserID))
            {
                return View();
            }

            return RedirectToAction("Index", "Home");           
        }

        [HttpPost]
        public async Task<ActionResult> Login(AuthenticationModel user)
        {
            var response = await authProvider.FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

            var userFirebaseToken = response.FirebaseToken;

            if (userFirebaseToken != null)
            { 
                HttpContext.Session.Add(AuthenticationConstants.SessionUserAuthToken, userFirebaseToken);

                var userId = response.User.LocalId;
                HttpContext.Session.Add(AuthenticationConstants.SessionUserId, userId);
                authProvider.UserID = userId;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Register(AuthenticationModel user) 
        {
            var isValidInput = !string.IsNullOrEmpty(user?.Email) && !string.IsNullOrEmpty(user?.Password);
            if (isValidInput) 
            {
                try
                {
                    await authProvider.FirebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

                    var signInUserResponse = await authProvider.FirebaseAuthProvider.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

                    var userAuthToken = signInUserResponse.FirebaseToken;

                    if (userAuthToken != null)
                    {
                        HttpContext.Session.Add("_userAuthToken", userAuthToken);

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return View("~/Views/Account/Register.cshtml");
        }
    }
}