using Fint.Web.Models.Nordigen;
using Fint.Web.Models.Nordigen.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fint.Web.Services.Nordigen.Interfaces
{
    public interface INordigenService
    {
        Task<BearerTokenData> GetBearerToken();
        Task<BearerTokenData> RefreshBearerToken();
        Task<AccountDetails> GetUserAccount();
    }
}