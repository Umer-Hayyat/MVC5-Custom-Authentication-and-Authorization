using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace MVCAuthAndAuthoWithDotNetFramework
{
    public static class StaticUtils
    {
        //static Func<string, string> ReadConfigKey = (string key) => { return ConfigurationManager.AppSettings[key]; };
        // Above and Below both works
        public static Func<string, string> ReadConfigKey = (string key) => ConfigurationManager.AppSettings[key];

        public static Func<string, string, List<Claim>> GetClaimsByRoleType = (string role, string userName) =>
          {
              List<Claim> claims = new List<Claim>();
              claims.Add(new Claim(ClaimTypes.Name, userName));
              claims.Add(new Claim(ClaimTypes.Role, role));
              claims.Add(new Claim(ClaimTypes.Role, "SuperUser"));
              //claims.Add(new Claim(ClaimTypes.Role, "User"));
              // TODO: add here any other claim you need
              return claims;
          };
        public static List<Claim> GetClaimsByRolesType(string userName, params string[] roles)
        {
            List<Claim> claims = new List<Claim>();
            if (roles?.Length > 0)
            {
                claims.Add(new Claim(ClaimTypes.Name, userName));

                foreach (string role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                };
            }

            return claims;
        }
    }
}