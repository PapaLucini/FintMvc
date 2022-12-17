using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Constants
{
    public static class NordigenApiConstants
    {
        public struct EndPoints
        {
            public static string NewBearerToken => "https://ob.nordigen.com/api/v2/token/new/";
        }
    }
}