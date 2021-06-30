//using Microsoft.Owin;
//using Microsoft.Owin.Security.DataHandler.Encoder;
//using Microsoft.Owin.Security.Jwt;
//using Owin;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;
//using Microsoft.Owin.Security;

//[assembly: OwinStartupAttribute(typeof(MVCAuthAndAuthoWithDotNetFramework.App_Start.Startup))]

//namespace MVCAuthAndAuthoWithDotNetFramework.App_Start
//{
//    public partial class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            ConfigureOAuthTokenConsumption(app);
//        }

//        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
//        {
//            var issuer = ConfigurationManager.AppSettings["Issuer"];
//            var audienceId = ConfigurationManager.AppSettings["AudienceId"];
//            var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);

//            app.UseJwtBearerAuthentication(
//                new JwtBearerAuthenticationOptions {
//                    AuthenticationMode = AuthenticationMode.Active,
//                    AllowedAudiences = new[] { audienceId },
//                    IssuerSecurityKeyProviders = new IIssuerSecurityKeyProvider[] {
//                        new SymmetricKeyIssuerSecurityKeyProvider(issuer, audienceSecret)
//                    }
//                });
//        }
//    }
//}