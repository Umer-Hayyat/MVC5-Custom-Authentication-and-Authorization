using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using System.Text;
using System.Configuration;

namespace MVCAuthAndAuthoWithDotNetFramework.CustomFilters
{
    public class CustomAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private static bool ValidateToken(string authToken, out IPrincipal principal)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, // Because there is no expiration in the generated token
                ValidateAudience = true, // Because there is no audiance in the generated token
                ValidateIssuer = true,   // Because there is no issuer in the generated token
                ValidIssuer = StaticUtils.ReadConfigKey("Issuer"),
                ValidAudience = StaticUtils.ReadConfigKey("AudienceId"),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(StaticUtils.ReadConfigKey("AudienceSecret"))) // The same key as the one that generate the token
            };
        }
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            try
            {
                HttpCookie authCookie = filterContext.HttpContext.Request.Cookies["Token"];
                if (authCookie != null)
                {
                    IPrincipal principal;
                    bool validated = ValidateToken(authCookie.Value, out principal);

                    filterContext.HttpContext.User = principal;
                }
                else
                {
                    throw new UnauthorizedAccessException();
                }
            }
            catch (Exception)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //Redirecting the user to the Login View of Account Controller  
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Accounts" },
                     { "action", "Login" }
                });
            }
        }
    }
}