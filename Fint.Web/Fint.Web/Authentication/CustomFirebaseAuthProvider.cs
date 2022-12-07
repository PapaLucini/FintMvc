using Fint.Web.Authentication.Interfaces;
using Fint.Web.Constants;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Fint.Web.Authentication
{
    public sealed class CustomFirebaseAuthProvider : ICustomAuthenticationProvider
    {
        public FirebaseAuthProvider FirebaseAuthProvider { get; }
        //public readonly FirebaseAuthProvider FirebaseAuthProvider;
        private static CustomFirebaseAuthProvider _instance { get; set; }
        public string UserID { get; set; }
        public string UserEmail { get; set; }

        private CustomFirebaseAuthProvider()
        {
            var apiKey = ConfigurationManager.AppSettings["FirebaseApiKey"];
            FirebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));

            UserID = HttpContext.Current.Session[AuthenticationConstants.SessionUserId]?.ToString() ?? string.Empty;
        }

        public static CustomFirebaseAuthProvider GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CustomFirebaseAuthProvider();
            }

            return _instance;
        }
    }
}