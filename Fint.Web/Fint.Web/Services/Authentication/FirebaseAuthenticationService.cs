using Fint.Web.Authentication.Interfaces;
using Fint.Web.Constants;
using Fint.Web.Models.Authentication.Interfaces;
using Fint.Web.Models.Database;
using Fint.Web.Services.Authentication.Interfaces;
using Fint.Web.Services.Nordigen.Interfaces;
using Firebase.Auth;
using HttpClientWrapper;
using HttpClientWrapper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace Fint.Web.Services.Authentication
{
    public class FirebaseAuthenticationService : IAuthenticationSerivce
    {
        private ICustomAuthenticationProvider authProvider;
        private INordigenService nordigenService;
        private IHttpClientService httpClientService;
        public FirebaseAuthenticationService(ICustomAuthenticationProvider authProvider, INordigenService nordigenService, IHttpClientService httpClientService)
        {
            this.authProvider = authProvider;
            this.nordigenService = nordigenService;
            this.httpClientService = httpClientService;     
        }


        public async Task<FirebaseAuthLink> CreateUser(IUser user)
        {
            try
            {
                var registerUserResponse = await authProvider.Provider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

                var userAuthToken = registerUserResponse.User.LocalId;

                await CreateUserOnDatabase(userAuthToken);

                return registerUserResponse;
            }
            catch (Exception ex)
            {
                return null;
            }            
        }

        public async Task<FirebaseAuthLink> AuthenticateUser(IUser user)
        {
            try
            {
                var signInUserResponse = await authProvider.Provider.SignInWithEmailAndPasswordAsync(user.Email, user.Password);

                HttpContext.Current.Session[Constants.AuthenticationConstants.SessionUserId] = !string.IsNullOrEmpty(signInUserResponse?.FirebaseToken)
                        ? signInUserResponse?.FirebaseToken
                        : string.Empty;

                return signInUserResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IUser> CreateUserOnDatabase(string userId)
        {
            var tokenData = nordigenService.GetBearerToken();
            var userData = new UserInfo()
            {
                UserId = userId,
                TokenData = tokenData.Result,
                Account = null
                
            };

            //var createUserOnDbRequestBuilder = RequestBuilder.CreateRequest()
            //                                    .HttpMethod(HttpMethod.Put)
            //                                    .WithBodyAsJson(userData)
            //                                    .Endpoint(FirebaseApiConstants.Database.EndPoint);

            using (var httpclient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(userData));
                var response = await httpclient.PutAsync(FirebaseApiConstants.Database.EndPoint, content);
            }
           

            return null;
        }

    }
}