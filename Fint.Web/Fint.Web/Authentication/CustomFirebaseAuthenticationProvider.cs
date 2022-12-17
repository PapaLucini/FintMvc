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
    public class CustomFirebaseAuthenticationProvider : ICustomAuthenticationProvider
    {

        public FirebaseAuthProvider Provider { get; set; }

        public CustomFirebaseAuthenticationProvider()
        {
            var apiKey = ConfigurationManager.AppSettings["FirebaseApiKey"];
            Provider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        }

    }
}