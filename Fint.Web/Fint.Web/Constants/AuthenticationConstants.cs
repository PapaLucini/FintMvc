using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace Fint.Web.Constants
{
    public static class AuthenticationConstants
    {
        private static readonly string userAuthToken = "_userAuthToken";
        private static readonly string userId = "_userId";

        public static string SessionUserId { get { return userId; } }
        public static string SessionUserAuthToken { get { return userAuthToken; } }
    }
}