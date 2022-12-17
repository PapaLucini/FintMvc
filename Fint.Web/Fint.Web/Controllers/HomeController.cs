using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fint.Web.Models.Nordigen.Authentication;
using Firebase.Database.Query;
using Firebase.Database;
using HttpClientWrapper;
using HttpClientWrapper.Constants;
using Fint.Web.Models;
using System.Threading.Tasks;

namespace Fint.Web.Controllers
{
    public class HomeController : Controller
    {
        public FirebaseClient firebaseClient = new FirebaseClient("https://fint-26951-default-rtdb.europe-west1.firebasedatabase.app/");
        public async Task<ActionResult> Index()
        {
            //Check if current user has token
            //var userStoredInfo = await firebaseClient.Child("UserInfo").Child("").OnceAsync<>();
            //Get Token
            //Store Token w user info



            //var y = await db.Child("ApiSettings").Child("Nordigen").OnceAsync<string>();
            //var settings = y?.Select(result => new KeyValuePair<string, ApiSettings>(result.Key, result.Object)).ToList();


            //var tokenRequest = new TokenRequest()
            //{
            //    SecretId = ConfigurationManager.AppSettings[""]
            //};

            //var bearerTokenRequestBuilder = RequestBuilder
            //                        .CreateRequest()
            //                        .Endpoint(ConfigurationManager.AppSettings["NordigenNewTokenApiUrl"].ToString())
            //                        .WithHeader(HttpRequestContants.HeadersNames.Accept, HttpRequestContants.HeadersValues.ApplicationJson)
            //                        .WithHeader(HttpRequestContants.HeadersNames.ContentType, HttpRequestContants.HeadersValues.ApplicationJson)
            //                        .WithBodyAsJson()
            //                        ;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}