using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace GSP.Web.Core.ActionFilters
{
    public class GSPAuthorize : AuthorizeAttribute
    {
        public GSPAuthorize(params string[] roles)
        {
            this.Roles = String.Join(", ", roles);
        }
    }
}
