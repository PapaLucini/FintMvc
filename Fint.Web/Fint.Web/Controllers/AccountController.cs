using Fint.Web.Services.Authentication.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fint.Web.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationSerivce authenticationSerivce;
        public string UniqueUserId { get; private set; }

        public AccountController(IAuthenticationSerivce authenticationSerivce)
        {
            this.authenticationSerivce = authenticationSerivce; 
        }

        public ActionResult Login()
        {
            if (string.IsNullOrEmpty(UniqueUserId))
            {
                return View();
            }

            return RedirectToAction("Index", "Home");           
        }

        [HttpPost]
        public async Task<ActionResult> Login(Models.Authentication.User user)
        {

            //await authenticationSerivce.AuthenticateUser(user);

            //var response = await authProvider.Provider.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

            //var userFirebaseToken = response.FirebaseToken;

            //if (userFirebaseToken != null)
            //{ 
            //    HttpContext.Session.Add(AuthenticationConstants.SessionUserAuthToken, userFirebaseToken);

            //    var userId = response.User.LocalId;
            //    HttpContext.Session.Add(AuthenticationConstants.SessionUserId, userId);
            //    authProvider.UserID = userId;
            //    return RedirectToAction("Index", "Home");
            //}

            //return View();


            return RedirectToAction("Index", "Home");

        }

        public ActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> Register(Models.Authentication.User user) 
        {
            var isValidInput = !string.IsNullOrEmpty(user?.Email) && !string.IsNullOrEmpty(user?.Password);

            var createUserResponse = await authenticationSerivce.CreateUser(user);

            if (createUserResponse != null)
            {
                RedirectToAction("Login");
            }
            //if (isValidInput) 
            //{
            //    try
            //    {
            //        await authProvider.Provider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

            //        var signInUserResponse = await authProvider.Provider.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

            //        var userAuthToken = signInUserResponse.FirebaseToken;

            //        if (userAuthToken != null)
            //        {
            //            HttpContext.Session.Add("_userAuthToken", userAuthToken);

            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            return View("~/Views/Account/Register.cshtml");
        }
    }
}