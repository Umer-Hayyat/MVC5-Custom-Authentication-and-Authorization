using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataHandler.Encoder;
using MVCAuthAndAuthoWithDotNetFramework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace MVCAuthAndAuthoWithDotNetFramework.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                HttpCookie cookie = new HttpCookie("Token", GetToken(model));
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Users");
            }
            return View(model);
        }

        public string GetToken(LoginModel model)
        {
            string audienceId = StaticUtils.ReadConfigKey("AudienceId");
            string symmetricKeyAsBase64 = StaticUtils.ReadConfigKey("AudienceSecret");
            string issuer = StaticUtils.ReadConfigKey("Issuer");

            byte[] keyByteArray = Encoding.UTF8.GetBytes(symmetricKeyAsBase64); 

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(keyByteArray);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            DateTimeOffset issued = DateTimeOffset.Now.ToUniversalTime();// data.Properties.IssuedUtc;

            DateTimeOffset expires = DateTimeOffset.Now.AddHours(1).ToUniversalTime();

            //List<Claim> claims = StaticUtils.GetClaimsByRoleType("Admin", model.UserName);
            List<Claim> claims = StaticUtils.GetClaimsByRolesType(model.UserName, "Admin", "SuperUser");

            JwtSecurityToken token = new JwtSecurityToken(issuer, audienceId, claims, issued.UtcDateTime, expires.UtcDateTime, signingCredentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

    }
}
