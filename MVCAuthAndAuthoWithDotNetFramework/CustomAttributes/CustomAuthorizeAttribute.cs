using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCAuthAndAuthoWithDotNetFramework.CustomAttributes
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.User.IsInRole("SuperUser");
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
        }
    }
}