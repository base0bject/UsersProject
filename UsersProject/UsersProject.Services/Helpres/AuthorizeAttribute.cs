using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using UsersProject.Core.Interfaces;

namespace UsersProject.Services.Helpers
{
    public class AuthorizeAttribute : AuthorizationFilterAttribute
    {
        private readonly IUserService _userService;

        public AuthorizeAttribute(IUserService userService)
        {
            _userService = userService;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                var decodeauthToken = Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                var arrUserNameAndPassword = decodeauthToken.Split(':');

                if (IsAuthorizedUser(arrUserNameAndPassword[0], arrUserNameAndPassword[1]))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(arrUserNameAndPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                 .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        public static bool IsAuthorizedUser(string Username, string Password)
        {
            // Service call
            return false;
        }
    }
}
