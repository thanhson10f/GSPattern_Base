using System.Security.Principal;
using GSP.Web.Core.Models;

namespace GSP.Web.Core.Extensions
{
    public static class SecurityExtensions
    {
        public static string Name(this IPrincipal user)
        {
            return user.Identity.Name;
        }

        public static bool InAnyRole(this IPrincipal user, params string[] roles)
        {
            foreach (string role in roles)
            {
                if (user.IsInRole(role)) return true;
            }
            return false;
        }
        public static GSPUser GetGSPUser(this IPrincipal principal)
        {
            if (principal.Identity is GSPUser)
                return (GSPUser)principal.Identity;
            else
                return new GSPUser(string.Empty, new UserInfo());
        }
    }   
}
